using System;
using System.Net.Sockets;

namespace ServerTest2.App
{
    public class Client
    {
        protected TcpClient TcpClient;

        protected int tempId;

        public Client(TcpClient tcpClient)
        {
            this.tempId = new Random().Next(1, 1000);
            TcpClient = tcpClient;
        }

        public TcpClient GetTcpClient()
        {
            return this.TcpClient;
        }
    }
}