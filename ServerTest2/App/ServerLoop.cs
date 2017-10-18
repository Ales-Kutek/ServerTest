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
            foreach (Client client in clients)
            {
                client.ReadBuffer(this.EntityManager);

                if (client.RoomStream.Count != 0)
                {
                    WriteRoomStream(clients, client);
                    client.SendRoomStream();
                }
            }
        }

        private void WriteRoomStream(List<Client> clients, Client sourceClient)
        {
            foreach (Entity entity in sourceClient.RoomStream)
            {
                foreach (Client client in clients)
                {
                    client.ReadRoomStream.Add(entity);
                }
            }
        }
    }
}