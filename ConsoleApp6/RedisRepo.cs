using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisSingletonPattern
{
    public class RedisRepo
    {
        #region Singleton pattern
        private readonly static Lazy<RedisRepo> _redisRepo = new Lazy<RedisRepo>(() => new RedisRepo());
        private readonly Lazy<ConnectionMultiplexer> _RedisConnection;
        private IDatabase redisdb;
        public RedisRepo()
        {
            _RedisConnection = new Lazy<ConnectionMultiplexer>(() => {

                return ConnectionMultiplexer.Connect("localhost:6379");
            });

            redisdb = _RedisConnection.Value.GetDatabase();
        }


        public static RedisRepo SingletonInstance
        {
            get
            {
                return _redisRepo.Value;
            }
        }
        #endregion



        public string GetValue(string key)
        {
           
            return redisdb.StringGet(key);
        }


    }
}
