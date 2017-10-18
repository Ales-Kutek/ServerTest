using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using EntityLib.lib.Entities;

namespace ClientTest2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            try // 1
//            {
               TcpClient tcp = new TcpClient("127.0.0.1", 8081);

                Client me = new Client(tcp);

                while (true)
                {
                    Console.WriteLine("tell me something nice...");

                    MessageEntity message = new MessageEntity();

                    message.Message = Console.ReadLine();

                    me.EntityManager.RequestNewEntity(message);

                    Thread.Sleep(1000);

                    string buffer = me.EntityManager.ReadBuffer();

                    Console.WriteLine("buffer:" + buffer);
                }

                Console.ReadKey();
//            }
//            catch (Exception exception)
//            {
//                Console.WriteLine("not connected..b.");
//            }
        }
    }
}