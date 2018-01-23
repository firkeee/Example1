using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Example1.Communication
{
    public class Client
    {
        TcpClient client;

        public Client()
        {
            client = new TcpClient();
            client.Connect(IPAddress.Loopback, 9090);

        }

        public void Send()
        {
            client.Client.Send(Encoding.UTF8.GetBytes("some message"));
        }
    }
}