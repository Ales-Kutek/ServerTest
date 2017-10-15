using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTest2
{
    internal class Program
    {
        private static string ReadBuffer(TcpClient client)
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = client.GetStream();
            int readByte;

            while (stream.DataAvailable)
            {
                buffer.Add(stream.ReadByte());
            }

            string result = Encoding.UTF8.GetString(buffer.Select<int, byte>(b => (byte) b).ToArray(), 0, buffer.Count);

            return result;
        }

        public static void Main(string[] args)
        {
            try // 1
            {
               TcpClient client = new TcpClient("127.0.0.1", 8081);

                while (true)
                {
                    var message = Console.ReadLine();
                    var buffer = Encoding.ASCII.GetBytes(message);

                    Console.WriteLine(buffer.Length);

                    client.GetStream().Write(buffer, 0, buffer.Length);
                    client.GetStream().Flush();

                    Console.WriteLine(ReadBuffer(client));
                }


                Console.ReadKey();
            }
            catch // 1
            {
                Console.WriteLine("not connected..b.");
            }
        }
    }
}