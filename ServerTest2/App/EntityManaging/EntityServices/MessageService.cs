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
            MessageEntity server = (MessageEntity) serverEntity;
            MessageEntity client = (MessageEntity) clientEntity;

            Console.WriteLine("Server" + server.Message);
            Console.WriteLine("Client" + client.Message);
        }
    }
}