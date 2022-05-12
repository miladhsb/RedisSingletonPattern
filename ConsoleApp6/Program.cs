using System;

namespace RedisSingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            var redis = RedisRepo.SingletonInstance;

            string key1 = Console.ReadLine();
            Console.WriteLine(redis.GetMeterKey(key1));
            string key2=  Console.ReadLine();
            Console.WriteLine(redis.GetMeterKey(key2));
            Console.ReadKey();
        }
    }
}
