using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace TcpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int port = 54321;
            IPAddress address = IPAddress.Parse("127.0.0.1");
            using(TcpClient client = new TcpClient())
            {
                client.Connect(address, port);
                if (client.Connected)
                {
                    var message = "Hello server | return this payload to sender!";
                    var bytes = Encoding.UTF8.GetBytes(message);
                    using (var requestStream = client.GetStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                    //The requestStream variable is an instance of the NetworkStream class created to write
                    //and read data over an open socket. With this, we'll be able to send our initial message,
                    //and then, eventually, read the response from the server then we can use our TcpListener
                    //instance to accept and parse an incoming request.
                }
            }
            Thread.Sleep(10000);
        }
    }
}



