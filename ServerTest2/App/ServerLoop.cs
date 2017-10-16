using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Lib.Entities;

namespace ServerTest2.App
{
    public class ServerLoop
    {
        public void Process(List <Client> clients)
        {
            foreach (var client in clients)
            {
                string buffer = ReadBuffer(client.GetTcpClient());

                if (buffer.Length != 0)
                {
                    ProcessRequest(buffer, client.GetTcpClient());
                }
            }
        }

        private void ProcessRequest(string buffer, TcpClient client)
        {
//            Console.WriteLine(buffer);

            byte[] bytes = Encoding.ASCII.GetBytes("OK");

            client.GetStream().Write(bytes, 0, bytes.Length);
            client.GetStream().Flush();
        }

        private string ReadBuffer(TcpClient client)
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = client.GetStream();

            while (stream.DataAvailable)
            {
                buffer.Add(stream.ReadByte());
            }

            string result = Encoding.UTF8.GetString(buffer.Select<int, byte>(b => (byte) b).ToArray(), 0, buffer.Count);

            if (result.Length == 0)
            {
                return result;
            }

            Console.WriteLine("byte");

            byte[] byteResult = Encoding.ASCII.GetBytes(result);

            Console.WriteLine(byteResult.Length);

            MemoryStream ms = new MemoryStream();
            ms.Write(byteResult, 0, byteResult.Length);
            ms.Flush();

            IFormatter formatter = new BinaryFormatter();

            ms.Position = 0;

            Console.WriteLine("beofre");

            try
            {
                var obj = (MessageEntity) formatter.Deserialize(ms);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("after");

            return result;
        }
    }
}