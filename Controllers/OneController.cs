using System.Net;
using System.Net.Http;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;


// 假设responseContent是从HttpClient获取到的响应内容



namespace net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneController : ControllerBase
    {
        //private readonly string url = "https://www.bilibili.com";
        //
        //用户id查询
        //https://tenapi.cn/bilibili/?uid=18180392

        [HttpGet]
        public async Task<ActionResult> GetConncetion (string member)
        {
            var (imgKey, subKey) = await ParamUrl.GetWbiKeys();

            Dictionary<string,string> signedParams = ParamUrl.EncWbi(
                parameters: new Dictionary<string,string> { { "mid",member } },
                imgKey: imgKey,
                subKey: subKey
            );

            string query = await new FormUrlEncodedContent(signedParams).ReadAsStringAsync();

            //Console.WriteLine(query);
            HttpClientManager clientManager = new HttpClientManager();
            string response = await clientManager.GetResponseAsync(query);

            await Console.Out.WriteLineAsync(response);
            return (Ok());
        }
    }
}
