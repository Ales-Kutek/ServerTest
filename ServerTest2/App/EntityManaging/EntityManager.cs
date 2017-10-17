using System;
using System.Collections.Generic;
using System.Reflection;
using EntityLib.lib;
using EntityLib.lib.Entities;

namespace ServerTest2.App.EntityManaging
{
    public class EntityManager
    {
        public EntityManager()
        {

        }

        public void ResolveEntity(Entity entity, Client client)
        {
            var entityList = client.GetEntityList();

            if (entityList.ContainsKey(entity.BackHash) == false)
            {
                var type = entity.GetType();

                Entity newInstance = (Entity) Activator.CreateInstance(type);

                entityList.Add(entity.BackHash, newInstance);
            }
        }
    }
}