using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ServerTest2.App;

namespace ServerTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.StartServer();
        }
    }
}