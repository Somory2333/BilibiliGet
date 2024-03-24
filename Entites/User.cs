namespace net8
{
    public class User
    {
        public uint Mid
        {
            get; set;
        }
        public string? Name
        {
            get; set;
        }
        public string? Birthday
        {
            get; set;
        }

        //粉丝勋章
        public bool? Fansbadge
        {
            get; set;
        }

        /// <summary>
        /// 用户类型,up主,普通用户
        /// </summary>
        public int Role
        {
            get; set;
        }

        public int Level
        {
            get; set;
        }

        public int Vip
        {
            get; set;
        }

        public string? Sex
        {
            get; set;
        }
        public string? Descripration
        {
            get; set;
        }

        /// <summary>
        /// 硬核会员,Lv6
        /// </summary>
        public int IsSeniorMember
        {
            get; set;
        }
        public string? School
        {
            get; set;
        }

        public int liveRoom
        {
            get; set;
        }

        public int LiveStatus
        {
            get; set;
        }

        public long VipLose
        {
            get; set;
        }
    }
}
