using System.Net;
using System.Net.Http;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadMoreController : ControllerBase
    {


        [HttpGet]
        public async Task<IEnumerable<string>> GetMessageAsync ()
        {
            // 设置时间间隔为 1 秒
            int intervalMilliseconds = 1000;

            Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();
            if (keyValuePairs == null)
            {
                keyValuePairs.Add("mid","");
            }

            Dictionary<string,string> signedParams = new Dictionary<string,string>();
            List<string> messages = new List<string>();
            Random rand = new Random();
            var (imgKey, subKey) = await ParamUrl.GetWbiKeys();


            using (HttpClient httpClient = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.All
            }))
            {

                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36 Edg/123.0.0.0"
                );
                httpClient.DefaultRequestHeaders.Accept.ParseAdd(
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
                );
                httpClient.DefaultRequestHeaders.Connection.ParseAdd("keep-alive");
                httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br, zstd");
                httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9,en;q=0.8");

                for (int i = 2;i < 5;i++)
                {
                    keyValuePairs["mid"] = i.ToString();
                    signedParams = ParamUrl.EncWbi(
                        parameters: keyValuePairs,
                        imgKey: imgKey,
                        subKey: subKey
                    );

                    string query = await new FormUrlEncodedContent(signedParams).ReadAsStringAsync();
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(
                    new HttpRequestMessage { RequestUri = new Uri($"https://api.bilibili.com/x/space/wbi/acc/info?{query}") });
                    var resolve = await httpResponseMessage.Content.ReadAsStringAsync();
                    messages.Add(resolve);

                }
                foreach (var message in messages)
                {

                    await Console.Out.WriteLineAsync(message);
                }

                return messages;



            }




        }

    }
    // GET: api/<ReadMoreController>

}




