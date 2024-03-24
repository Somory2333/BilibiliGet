using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.Json;

using Amazon.Runtime.Internal.Endpoints.StandardLibrary;

using Microsoft.AspNetCore.DataProtection;

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
            _httpClient.DefaultRequestHeaders.Upgrade.ParseAdd("1");
            _httpClient.DefaultRequestHeaders.Add("Cache-Control","0");
            _httpClient.DefaultRequestHeaders.Add("Cookie",CookieRead());
        }

        public string CookieRead ()
        {
            string Truevalue = "";
            try
            {
                string secret = File.ReadAllText(@"C:\Cookie\secrets.json");
                // 读取JSON文件内容


                // 使用 JsonDocument 解析 JSON
                using (JsonDocument document = JsonDocument.Parse(secret))
                {
                    // 获取根元素
                    JsonElement root = document.RootElement;

                    // 检查是否存在该键
                    if (root.TryGetProperty("Cookie",out JsonElement value))
                    {
                        // 获取键对应的值
                        Console.WriteLine($"Value: {value.GetString()}");
                        Truevalue = value.ToString();
                    }
                    else
                    {
                        Console.WriteLine("指定的键不存在。");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("JSON文件未找到。");
            }
            catch (JsonException)
            {
                Console.WriteLine("无法解析JSON文件。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生了错误: {ex.Message}");
            }
            return Truevalue;

        }

        public async Task<string> GetResponseAsync (string query,CancellationToken cancellationToken)
        {
            string user_agent = randomRead.OpenTextAsync().Result;

            //await Console.Out.WriteLineAsync(user_agent);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                user_agent
            );
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"https://api.bilibili.com/x/space/wbi/acc/info?{query}");
                int d = Thread.CurrentThread.ManagedThreadId;
                await Console.Out.WriteLineAsync("threadid" + d);
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

                            //Console.WriteLine(responseBody);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (OperationCanceledException)
            {
                // 用户取消操作时的处理
                Console.WriteLine($"Request to url was canceled.");
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine($"Error occurred while requesting url: {ex.Message}");
            }
            return "";
        }



        public void Dispose ()
        {
            _httpClient.Dispose();
        }
    }
}
