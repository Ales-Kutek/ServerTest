using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using EntityLib.lib;

namespace ClientTest2
{
    public class EntityManager
    {
        private EntityList entities = new EntityList();

        private Client client;

        public EntityManager(Client client)
        {
            this.client = client;
        }

        private void SendBufferAsString(string message)
        {

            var buffer = Encoding.ASCII.GetBytes(message);

            client.Tcp.GetStream().Write(buffer, 0, buffer.Length);
            client.Tcp.GetStream().Flush();
        }

        private void SendBufferAsBytes(byte[] buffer)
        {
            client.Tcp.GetStream().Write(buffer, 0, buffer.Length);
            client.Tcp.GetStream().Flush();
        }

        public Entity[] ReadBuffer()
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = this.client.Tcp.GetStream();

            while (stream.DataAvailable)
            {
                buffer.Add(stream.ReadByte());
            }

            byte[] result = buffer.Select<int, byte>(b => (byte) b).ToArray();

            if (result.Length == 0)
            {
                throw new Exception("No result");
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(result, 0, result.Length);
            ms.Flush();

            IFormatter formatter = new BinaryFormatter();

            ms.Position = 0;

            Entity[] entity = (Entity[]) formatter.Deserialize(ms);

            return entity;
        }

        public void RequestNewEntity(Entity entity)
        {
            entity.Time = DateTime.Now.Millisecond;

            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            formatter.Serialize(ms, entity);

            this.SendBufferAsBytes(ms.ToArray());
        }
    }
}