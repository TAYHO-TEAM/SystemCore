namespace Services.Common.Options
{
    public class RedisServerOptions
    {
        public string Host { get; set; }
        public string BlackListUserKey { get; set; }
        public int AbsoluteExpiration { get; set; }
        public int SlidingExpiration { get; set; }
    }
}