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
        public async Task<IEnumerable<string>> GetMessageAsync ([FromServices] HttpClientManager httpClientManager)
        {
            // 设置时间间隔为 1 秒
            int intervalMilliseconds = 100;

            Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();
            if (keyValuePairs == null)
            {
                keyValuePairs.Add("mid","");
            }

            Dictionary<string,string> signedParams = new Dictionary<string,string>();
            List<string> messages = new List<string>();
            Random rand = new Random();
            var (imgKey, subKey) = await ParamUrl.GetWbiKeys();




            for (int i = 2;i < 5;i++)
            {
                keyValuePairs["mid"] = i.ToString();
                signedParams = ParamUrl.EncWbi(
                    parameters: keyValuePairs,
                    imgKey: imgKey,
                    subKey: subKey
                );

                string query = await new FormUrlEncodedContent(signedParams).ReadAsStringAsync();
                var resolve = await httpClientManager.GetResponseAsync(query);

                messages.Add(resolve);
                Thread.Sleep(intervalMilliseconds);
            }
            foreach (var message in messages)
            {

                await Console.Out.WriteLineAsync(message);
            }

            return messages;








        }

    }
    // GET: api/<ReadMoreController>

}




