
using System.Threading;

namespace ErrorHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 24; i++)
            {
                Console.WriteLine($"Polly Demo Attempt {i}");
                Console.WriteLine("-------------");
                PollyDemo.ExecuteRemoteLookup();
                Console.WriteLine("-------------");
                Thread.Sleep(5000);
            }
        }
    }
}

