using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace TcpServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           using (var client = new UdpClient(34567))
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.01"), 45678);

                client.Connect(remoteEndPoint);

                var message = "Testing UDP";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                await client.SendAsync(messageBytes, messageBytes.Length, remoteEndPoint);

                var response = await client.ReceiveAsync();
                var responseMessage = Encoding.UTF8.GetString(response.Buffer);
                Console.WriteLine(responseMessage);

                Thread.Sleep(10000);
            }
        }
    }
}

/// whenever you're sending a message using UDP (or any other connectionless protocol),
/// it is an inherently non-blocking operation. This is due to the lack of any sort of acknowledgment from the server.
///
/// meanwhile he Receive() operation in UDP is inherently blocking. Since there's no established connection or stream
/// buffer to hold an incoming message until our server or client is ready to process the packet, any software we right
/// that must accept and receive UDP packets will have to be very explicit about when and how long it is acceptable to
/// block our execution while we wait for a packet that may never arrive
///




