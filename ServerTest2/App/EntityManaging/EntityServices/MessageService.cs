using System;
using EntityLib.lib;
using EntityLib.lib.Entities;

namespace ServerTest2.App.EntityManaging.EntityServices
{
    public class MessageService: Service
    {
        public MessageService(EntityManager entityManager) : base(entityManager)
        {
        }

        public override bool ResolveNew(Entity entity)
        {
            return true;
        }

        public override void Update(Entity serverEntity, Entity clientEntity)
        {
            MessageEntity serverCast = (MessageEntity) serverEntity;
            MessageEntity clientCast = (MessageEntity) clientEntity;
            Client client = (Client) serverCast.Owner;

            Console.WriteLine("Server" + serverCast.Message);
            Console.WriteLine("Client" + clientCast.Message);

            serverCast.Message = clientCast.Message;

            client.RoomStream.Add(serverCast);
        }
    }
}