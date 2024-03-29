using MongoDB.Bson;

namespace net8.Entites
{
    public class VideoInfomation
    {
        public long aid
        {
            get; set;
        }

        public int tid
        {
            get; set;
        }
        public string? tname
        {
            get; set;
        }
        public string title
        {
            get; set;
        }
        /// <summary>
        /// 用户投稿时间
        /// </summary>
        public long ctime
        {
            get; set;
        }

        public int view
        {
            get; set;
        }

        public int danmaku
        {
            get; set;
        }
        public int reply
        {
            get; set;
        }

        /// <summary>
        /// 收藏数
        /// </summary>
        public int favorite
        {
            get; set;
        }
        public int coin
        {
            get; set;
        }
        public int share
        {
            get; set;
        }
        public int now_rank
        {
            get; set;
        }
        /// <summary>
        /// 最高i排名
        /// </summary>
        public int his_rank
        {
            get; set;
        }
        public int like
        {
            get; set;
        }
        public DateTime DateTime
        {
            get; set;
        }
    }
}
