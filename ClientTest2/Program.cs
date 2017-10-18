using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using EntityLib.lib;
using EntityLib.lib.Entities;

namespace ClientTest2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            try // 1
//            {
//               TcpClient tcp = new TcpClient("127.0.0.1", 8081);
               TcpClient tcp = new TcpClient("127.0.0.1", 8081);

                Client me = new Client(tcp);

                while (true)
                {
                    MessageEntity message = new MessageEntity();

                    message.Message = Console.ReadLine();

                    me.EntityManager.RequestNewEntity(message);

                    Thread.Sleep(1000);

                    try
                    {
                        Entity[] entities = me.EntityManager.ReadBuffer();

                        foreach (Entity readEntity in entities)
                        {
                            var messageEntity = (MessageEntity) readEntity;
                            Console.WriteLine(messageEntity.Message);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
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