using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TcpServer
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            int port = 54321;
            IPAddress address = IPAddress.Any;
            TcpListener server = new TcpListener(address, port);
            server.Start();

            var loggedNoRequest = false;
            byte[] bytes = new byte[256];

            using (var client = await server.AcceptTcpClientAsync())
            {
                using (var tcpStream = client.GetStream())
                {
                    await tcpStream.ReadAsync(bytes, 0, bytes.Length);
                    var requestMessage = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine(requestMessage);
                }
            }
            //var loggedPending = false;

            //while (true)
            //{
            //    if (server.Pending())
            //    {
            //        if (!loggedNoRequest)
            //        {
            //            Console.WriteLine("No pending request as of yet");
            //            Console.WriteLine("Server listening...");
            //            loggedNoRequest = true;
            //        }
            //    }
            //    else
            //    {
            //        if (!loggedPending)
            //        {
            //            Console.WriteLine("Pending TCP Request");
            //            loggedPending = true;
            //        }
            //    }
            //}
        }
    }
}

