using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace net8
{
    public class UserFilterData
    {
        public IEnumerable<User> Filter (IEnumerable<string> filter)
        {
            List<User> messages = new List<User>();

            foreach (var item in filter)
            {

                var jsonString = JsonConvert.DeserializeObject<dynamic>(item);
                uint mid = (uint)jsonString["data"]["mid"];
                string name = (string)jsonString["data"]["name"];
                string? sex = jsonString["data"]["sex"];
                string? sign = jsonString["data"]["sign"];
                int level = (int)jsonString["data"]["level"];
                bool fan = jsonString["data"]["fans_badge"];
                int role = jsonString["data"]["official"]["role"];
                int vip = jsonString["data"]["vip"]["type"];
                int isSeniorMember = jsonString["data"]["is_senior_member"];
                long vipLose = jsonString["data"]["vip"]["due_date"];
                int liveRoom;
                int roomStatu;
                if (jsonString["data"]["live_room"] is JValue)
                {

                    liveRoom = 0;
                    roomStatu = 0;
                }
                else
                {
                    liveRoom = jsonString["data"]["live_room"]["roomStatus"];
                    roomStatu = jsonString["data"]["live_room"]["liveStatus"];
                }



                string? birthday = jsonString["data"]["birthday"];
                string? school;
                if (jsonString["data"]["school"] is JValue)
                {
                    school = jsonString["data"]["school"];
                }
                else
                {
                    school = jsonString["data"]["school"]["name"];
                }

                if (level > 1)
                {
                    messages.Add(new User
                    {
                        Mid = mid,
                        Name = name,
                        Sex = sex,
                        Descripration = sign,
                        Level = level,
                        Fansbadge = fan,
                        Role = role,
                        Vip = vip,
                        VipLose = vipLose,
                        Birthday = birthday,
                        School = school,
                        liveRoom = liveRoom,
                        LiveStatus = roomStatu,
                        IsSeniorMember = isSeniorMember
                    });

                }
                if (messages.Count % 3 == 0)
                {
                    InsertUser.InsertUserData(messages);
                    //messages = null;
                }
                Console.WriteLine("mid=" + mid);


            }
            return messages;
        }
    }
}
