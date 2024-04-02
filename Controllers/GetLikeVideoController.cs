using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using net8.Database;
using net8.Entites;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLikeVideoController : ControllerBase
    {
        [HttpGet]
        public async void GetRecentLikeVideo ([FromServices] HttpClientManager httpClientManager,uint vmid)
        {
            string baseUrl = "https://api.bilibili.com/x/space/like/video?";
            var urlBuilder = new UriBuilder(baseUrl);
            urlBuilder.Query = $"vmid={vmid}";
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
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<JObject>(responseContent);
                    if ((int)jsonObject["code"] == -400)
                    {
                        await Console.Out.WriteLineAsync("请求错误");
                        return;
                    }
                    if ((int)jsonObject["code"] == 53013)
                    {
                        await Console.Out.WriteLineAsync("用户隐私未公开");
                        return;
                    }
                    if ((int)jsonObject["code"] == 0)
                    {
                        if (jsonObject["data"] != null)
                        {
                            UserLikeVideo userLikes = new UserLikeVideo();
                            List<VideoInfomation> videos = new List<VideoInfomation>();
                            long mid = vmid;
                            var videoArray = jsonObject["data"]["list"] as JArray;
                            foreach (var item in videoArray)
                            {

                                VideoInfomation infomation = new VideoInfomation
                                {
                                    aid = (long)item["aid"],
                                    tid = (int)item["tid"],
                                    tname = (string)item["tname"],
                                    title = (string)item["title"],
                                    ctime = (long)item["ctime"],
                                    view = (int)item["stat"]["view"],
                                    danmaku = (int)item["stat"]["danmaku"],
                                    reply = (int)item["stat"]["reply"],
                                    favorite = (int)item["stat"]["favorite"],
                                    coin = (int)item["stat"]["coin"],
                                    share = (int)item["stat"]["share"],
                                    now_rank = (int)item["stat"]["now_rank"],
                                    his_rank = (int)item["stat"]["his_rank"],
                                    like = (int)item["stat"]["like"],

                                };
                                await Console.Out.WriteLineAsync(infomation.tname);
                                videos.Add(infomation);
                                if (videoArray.Next == null)
                                {
                                    userLikes.Mid = mid;
                                    userLikes.VideoInfomation = videos;
                                }

                            }
                            InsertCoinVideo.InsertLikeVideoData(userLikes);

                        }
                        else
                        {
                            return;
                        }
                    }
                }


            }
        }
    }
}
