using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Communication
{
    public class ClientHandler
    {
        Socket clientSocket;
        byte[] buffer = new byte[512];

        public ClientHandler(Socket socket)
        {
            clientSocket = socket;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            string message;

            while (true)
            {
                length = clientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
            }
        }
    }
}