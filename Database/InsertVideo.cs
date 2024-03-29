using MongoDB.Driver;

using net8.Entites;

namespace net8.Database
{
    public class InsertVideo
    {
        // MongoDB连接字符串
        private static readonly string connectionString = "mongodb://localhost:27017";

        // 连接到MongoDB服务器
        private static MongoClient client = new MongoClient(connectionString);


        public static void InsertVideoData (IEnumerable<VideoInfomation> strings)
        {
            // 获取数据库
            var database = client.GetDatabase("BiliData");

            // 获取集合
            var collection = database.GetCollection<VideoInfomation>("BVideo");


            // 批量插入数据
            BulkInsertData(collection,(List<VideoInfomation>)strings);

            Console.WriteLine("All data inserted into MongoDB.");
        }

        private static void BulkInsertData (IMongoCollection<VideoInfomation> collection,List<VideoInfomation> jsonStrings)
        {


            collection.InsertMany(jsonStrings);


        }
    }
}
