using System;
using System.Collections.Generic;
using System.Net.Sockets;
using EntityLib.lib;

namespace ServerTest2.App
{
    public class Client
    {
        protected TcpClient TcpClient;

        protected int tempId;

        protected Dictionary<int, Entity> entities = new Dictionary<int, Entity>();

        public Client(TcpClient tcpClient)
        {
            this.tempId = new Random().Next(1, 1000);
            TcpClient = tcpClient;
        }

        public TcpClient GetTcpClient()
        {
            return this.TcpClient;
        }

        public Dictionary<int, Entity> GetEntityList()
        {
            return this.entities;
        }
    }
}