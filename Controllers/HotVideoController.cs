using System.Net;
using System.Net.Http;

using Azure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson.IO;

using net8.Database;
using net8.Entites;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotVideoController : ControllerBase
    {
        private string baseUrl = "https://api.bilibili.com/x/web-interface/popular?";
        private int page = 1;
        private int pageSize = 20;
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
                    List<VideoInfomation> videoInfomations = new List<VideoInfomation>();
                    // 读取响应内容
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<JObject>(responseContent);
                    var videoArray = jsonObject["data"]["list"] as JArray;
                    foreach (var item in videoArray)
                    {
                        await Console.Out.WriteLineAsync(item.ToString());
                        long aid = (long)item["aid"];
                        int tid = (int)item["tid"];
                        string tname = (string)item["tname"];
                        string title = (string)item["title"];
                        long ctime = (long)item["ctime"];
                        int view = (int)item["stat"]["view"];
                        int danmaku = (int)item["stat"]["danmaku"];
                        int reply = (int)item["stat"]["reply"];
                        int favorite = (int)item["stat"]["favorite"];
                        int coin = (int)item["stat"]["coin"];
                        int share = (int)item["stat"]["share"];
                        int now_rank = (int)item["stat"]["now_rank"];
                        int his_rank = (int)item["stat"]["his_rank"];
                        int like = (int)item["stat"]["like"];
                        DateTime dateTime = DateTime.Now;

                        videoInfomations.Add(new VideoInfomation
                        {
                            aid = aid,
                            tid = tid,
                            tname = tname,
                            title = title,
                            ctime = ctime,
                            view = view,
                            danmaku = danmaku,
                            reply = reply,
                            favorite = favorite,
                            coin = coin,
                            share = share,
                            now_rank = now_rank,
                            his_rank = his_rank,
                            like = like,
                            DateTime = dateTime

                        });


                    }
                    await Console.Out.WriteLineAsync();
                    //Console.WriteLine(responseContent);
                    InsertVideo.InsertVideoData(videoInfomations);
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
