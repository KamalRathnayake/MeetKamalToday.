using ServiceStack.Redis;
using System;

namespace RedisDemo
{
    class Program
    {
        static string redisConnectionString = "UltPIPyhANxLjYnTqUNRsuijoTpPfd7O9AzCaJaiybg=@redisdemo20211119.redis.cache.windows.net:6380?ssl=true";
        static void Main(string[] args)
        {
            using (RedisClient redisClient = new RedisClient(redisConnectionString))
            using (var transaction = redisClient.CreateTransaction())
            {
                transaction.QueueCommand(c => c.Set("K1", "Ann"));
                transaction.QueueCommand(c => c.Set("K2", "Bob"));

                var isSuccess = transaction.Commit();
                Console.WriteLine(isSuccess);
            }
        }
    }
}
