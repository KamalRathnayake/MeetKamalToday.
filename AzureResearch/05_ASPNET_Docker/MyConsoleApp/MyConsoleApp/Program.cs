using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine($"Hello from container {DateTime.Now}");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}