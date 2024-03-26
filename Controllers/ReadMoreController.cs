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
        private UserFilterData filter;

        [HttpGet]
        public async Task<IEnumerable<User>> GetMessageAsync ([FromServices] HttpClientManager httpClientManager)
        {
            filter = new UserFilterData();

            Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();
            if (keyValuePairs == null)
            {
                keyValuePairs.Add("mid","");
            }

            Dictionary<string,string> signedParams = new Dictionary<string,string>();
            List<string> messages = new List<string>();
            Random rand = new Random();
            var (imgKey, subKey) = await ParamUrl.GetWbiKeys();
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                List<Task<string>> tasks = new List<Task<string>>();
                // 创建一个 CancellationToken 以便传递给每个任务
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                for (int i = 10;i < 15;i++)
                {
                    keyValuePairs["mid"] = i.ToString();
                    signedParams = ParamUrl.EncWbi(
                        parameters: keyValuePairs,
                        imgKey: imgKey,
                        subKey: subKey
                    );

                    string query = await new FormUrlEncodedContent(signedParams).ReadAsStringAsync();
                    tasks.Add(httpClientManager.GetResponseAsync(query,cancellationToken));

                    await Task.WhenAny(Task.WhenAll(tasks),Task.Delay(-1,cancellationToken));

                    // 如果用户取消了操作，取消剩余的任务
                    cancellationTokenSource.Cancel();

                    messages.Add(tasks[i - 10].Result);
                    //Thread.Sleep(intervalMilliseconds);
                }
            }

            var result = filter.Filter(messages);

            return result;
        }




    }
}




