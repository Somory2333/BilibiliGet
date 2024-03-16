using System.IO.Compression;
using System.Net;
using System.Text;

namespace net8
{
    public class HttpClientManager : IDisposable
    {
        private HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.All



        });
        private readonly RandomRead randomRead = new RandomRead();


        public HttpClientManager ()
        {



            _httpClient.DefaultRequestHeaders.Accept.ParseAdd(
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
            _httpClient.DefaultRequestHeaders.AcceptCharset.ParseAdd("utf-8");
            _httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9,en;q=0.8");

        }

        public async Task<string> GetResponseAsync (string query)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                randomRead.OpenTextAsync().Result
            );
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.bilibili.com/x/space/wbi/acc/info?{query}");

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as stream
                Stream responseStream = await response.Content.ReadAsStreamAsync();

                // Check if the response is gzip compressed
                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    // Decompress the response stream using GZipStream
                    using (var gzipStream = new GZipStream(responseStream,CompressionMode.Decompress))
                    {
                        using (var reader = new StreamReader(gzipStream))
                        {
                            // Read the decompressed stream as string
                            string responseBody = await reader.ReadToEndAsync();

                            // Now you can work with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
                else
                {
                    // If not gzip compressed, read the stream as string directly
                    using (var reader = new StreamReader(responseStream,Encoding.Latin1



                        ))
                    {
                        string responseBody = await reader.ReadToEndAsync();

                        Console.WriteLine(responseBody);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
            }
            return await response.Content.ReadAsStringAsync();
        }



        public void Dispose ()
        {
            _httpClient.Dispose();
        }
    }
}
