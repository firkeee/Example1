using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example1.Communication
{
    public class Server
    {
        public ObservableCollection<ClientHandler> clients;
        TcpListener tcpServer;

        public Server()
        {
            clients = new ObservableCollection<ClientHandler>();

            tcpServer = new TcpListener(IPAddress.Loopback, 9090);
            tcpServer.Start();
            Thread thread = new Thread(StartReceiving);
            thread.Start();
        }

        private void StartReceiving()
        {
            clients.Add(new ClientHandler(tcpServer.AcceptSocket()));
        }

        
    }
}
