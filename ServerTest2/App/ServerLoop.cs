using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using EntityLib.lib;
using EntityLib.lib.Entities;
using ServerTest2.App.EntityManaging;

namespace ServerTest2.App
{
    public class ServerLoop
    {
        public EntityManager EntityManager { get; } = new EntityManager();

        public void Process(List <Client> clients)
        {
            foreach (var client in clients)
            {
                ReadBuffer(client);
            }
        }

        private void ProcessRequest(string buffer, TcpClient client)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("OK");

            client.GetStream().Write(bytes, 0, bytes.Length);
            client.GetStream().Flush();
        }

        private bool ReadBuffer(Client client)
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = client.GetTcpClient().GetStream();

            while (stream.DataAvailable)
            {
                buffer.Add(stream.ReadByte());
            }

            byte[] result = buffer.Select<int, byte>(b => (byte) b).ToArray();

            if (result.Length == 0)
            {
                return false;
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(result, 0, result.Length);
            ms.Flush();

            IFormatter formatter = new BinaryFormatter();

            ms.Position = 0;

            try
            {
                var entity = (Entity) formatter.Deserialize(ms);

                this.EntityManager.ResolveEntity(entity, client);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return true;
        }
    }
}