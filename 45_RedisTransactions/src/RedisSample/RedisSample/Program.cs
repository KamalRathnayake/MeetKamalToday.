using System;
using ServiceStack.Redis;

namespace RedisSample
{
    class Program
    {
        static string redisConnectionString = "";
        static void Main(string[] args)
        {
            bool transactionResult = false;

            using (RedisClient redisClient = new RedisClient(redisConnectionString))
            using (var transaction = redisClient.CreateTransaction())
            {
                transaction.QueueCommand(c => c.Set("K1", "Ann2"));
                transaction.QueueCommand(c => c.Set("K2", "Bob"));

                transactionResult = transaction.Commit();
            }

            if (transactionResult)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
}
