using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Cache
{
    public  class CacheConfig
    {
        public bool CacheEnable { get; set; }
        public RedisConfig Redis { get; set; }
    }
    public class RedisConfig
    {
        public string IP { get; set; }
        public int Port { get; set; } = 6559;
        public string Password { get; set; }
        public int DB { get; set; } = 0;
        public int Timeout { get; set; } = 30000;
    }
}
