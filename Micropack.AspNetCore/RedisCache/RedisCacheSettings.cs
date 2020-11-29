namespace Micropack.AspNetCore.RedisCache
{
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }

        public int DefaultSecondsToCache { get; set; }
    }
}
