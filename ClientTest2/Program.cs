using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Lib.Entities;

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

//                while (true)
//                {
                    MessageEntity message = new MessageEntity();

                    message.Message = Console.ReadLine();

                    me.EntityManager.RequestNewEntity(message);
//                }


                Console.ReadKey();
//            }
//            catch (Exception exception)
//            {
//                Console.WriteLine("not connected..b.");
//            }
        }
    }
}