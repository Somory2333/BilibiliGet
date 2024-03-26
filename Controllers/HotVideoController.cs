using System.Net;
using System.Net.Http;

using Azure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotVideoController : ControllerBase
    {
        private string baseUrl = "https://api.bilibili.com/x/web-interface/popular?";
        private int page = 1;
        private int pageSize = 1;
        [HttpGet]
        public async Task GetVideoList ()
        {

            var urlBuilder = new UriBuilder(baseUrl);
            urlBuilder.Query = $"Pn={page}&Ps={pageSize}";

            using (HttpClient _httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            }))
            {
                _httpClient.DefaultRequestHeaders.Accept.ParseAdd(
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
            );
                _httpClient.DefaultRequestHeaders.AcceptCharset.ParseAdd("utf-8");
                _httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br, zstd");
                _httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9,en;q=0.8");
                var response = await _httpClient.GetAsync(urlBuilder.Uri);
                if (response.IsSuccessStatusCode)
                {
                    // 读取响应内容
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"请求失败: {response.StatusCode}");
                }

                return;
            }
        }
    }
}
