

using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;
using MongoDB.Driver;

using Newtonsoft.Json;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace net8
{


    public class InsertUser
    {


        // MongoDB连接字符串
        private static readonly string connectionString = "mongodb://localhost:27017";

        // 连接到MongoDB服务器
        private static MongoClient client = new MongoClient(connectionString);


        public static void InsertUserData (IEnumerable<User> strings)
        {
            // 获取数据库
            var database = client.GetDatabase("BiliData");

            // 获取集合
            var collection = database.GetCollection<User>("BUser");


            // 批量插入数据
            BulkInsertData(collection,(List<User>)strings);

            Console.WriteLine("All data inserted into MongoDB.");
        }

        private static void BulkInsertData (IMongoCollection<User> collection,List<User> jsonStrings)
        {


            collection.InsertMany(jsonStrings);


        }








    }
}

