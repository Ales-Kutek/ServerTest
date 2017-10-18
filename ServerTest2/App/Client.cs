using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EntityLib.lib;
using ServerTest2.App.EntityManaging;

namespace ServerTest2.App
{
    public class Client: Owner
    {
        protected TcpClient TcpClient;

        public int tempId;

        protected Dictionary<int, Entity> entities = new Dictionary<int, Entity>();

        private List<Entity> roomStream = new List<Entity>();

        private List<Entity> readRoomStream = new List<Entity>();

        public List<Entity> RoomStream
        {
            get => roomStream;
        }

        public List<Entity> ReadRoomStream
        {
            get => readRoomStream;
        }

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


        public bool ReadBuffer(EntityManager entityManager)
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = this.GetTcpClient().GetStream();

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

                entityManager.SyncEntity(entity, this);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return true;
        }

        public void SendRoomStream()
        {
            if (ReadRoomStream.Count != 0)
            {
                IFormatter formatter = new BinaryFormatter();

                Entity[] entities = ReadRoomStream.ToArray();

                var networkStream = this.GetTcpClient().GetStream();

                formatter.Serialize(networkStream, entities);
                networkStream.Flush();

                Console.WriteLine("clear in " + this.tempId);

                RoomStream.Clear();
                ReadRoomStream.Clear();
            }
        }
    }
}