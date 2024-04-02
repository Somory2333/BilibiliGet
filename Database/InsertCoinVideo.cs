using MongoDB.Driver;

using net8.Entites;

namespace net8.Database
{
    public class InsertCoinVideo
    {
        // MongoDB连接字符串
        private static readonly string connectionString = "mongodb://localhost:27017";

        // 连接到MongoDB服务器
        private static MongoClient client = new MongoClient(connectionString);


        public static void InsertCoinVideoData (UserLikeVideo entity)
        {
            // 获取数据库
            var database = client.GetDatabase("BiliData");

            // 获取集合
            var collection = database.GetCollection<UserLikeVideo>("BCoinVideo");


            collection.InsertOne(entity);

            Console.WriteLine("All data inserted into MongoDB.");
        }
        public static void InsertLikeVideoData (UserLikeVideo entity)
        {
            // 获取数据库
            var database = client.GetDatabase("BiliData");

            // 获取集合
            var collection = database.GetCollection<UserLikeVideo>("BLikeVideo");


            collection.InsertOne(entity);

            Console.WriteLine("All data inserted into MongoDB.");
        }


    }
}
