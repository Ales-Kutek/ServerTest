using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Lib;

namespace ServerTest2.App
{
    public class Client
    {
        protected TcpClient TcpClient;

        protected int tempId;

        protected EntityList entities = new EntityList();

        public Client(TcpClient tcpClient)
        {
            this.tempId = new Random().Next(1, 1000);
            TcpClient = tcpClient;
        }

        public TcpClient GetTcpClient()
        {
            return this.TcpClient;
        }

        public EntityList GetEntityList()
        {
            return this.entities;
        }
    }
}