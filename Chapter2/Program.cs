using System;
using System.Net;
using System.Threading;

// Build a URI
//namespace UriTests
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var simpleUri = GetSimpleUri();
//            Console.WriteLine(simpleUri.ToString());
//            Thread.Sleep(10000);
//        }
//        public static Uri GetSimpleUri()
//        {
//            //var builder = new UriBuilder();
//            //builder.Scheme = "http";
//            //builder.Host = "packt.com";
//            // its better to us the constructor overloads to initialize the UriBuilder class
//            var builder = new UriBuilder("http", "packt");
//            return builder.Uri;
//        }
//    }
//}
//we can access ccess host information for a given domain name or IP address using the Dns class.
//Note that the instance of the HostEntry class returned by the methods of the Dns class always
//contain all of the IP addresses for which there is a record in the naming server
namespace DNSTest
{
    public class DnsTestProgram
    {
        public static void Main(string[] args)
        {
            var domainEntry = Dns.GetHostEntry("google.com");
            Console.WriteLine(domainEntry.HostName);
            foreach (var ip in domainEntry.AddressList)
            {
                Console.WriteLine(ip);
            }
            Thread.Sleep(10000);
        }
    }
}