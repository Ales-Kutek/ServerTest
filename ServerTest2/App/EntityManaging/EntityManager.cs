using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting;
using EntityLib.lib;
using EntityLib.lib.Entities;
using ServerTest2.App.EntityManaging.EntityServices;

namespace ServerTest2.App.EntityManaging
{
    public class EntityManager
    {
        private EntityServiceList _entityServiceList = new EntityServiceList();

        public EntityManager()
        {
            _entityServiceList.Add(typeof(MessageEntity).FullName, new MessageService(this));
        }

        public void ResolveEntity(Entity entity, Client client)
        {
            var entityList = client.GetEntityList();

            if (entityList.ContainsKey(entity.BackHash) == false)
            {
                var type = entity.GetType();
                string fullName = type.FullName;

                Service entityService = this._entityServiceList[fullName];

                if (entityService.ResolveNew(entity))
                {
                    Entity newInstance = (Entity) Activator.CreateInstance(type);
                    entityList.Add(entity.BackHash, newInstance);

                    newInstance.OnUpdate.Add(delegate(Entity updated)
                    {
                        entityService.Update(newInstance, updated);
                    });

                    newInstance.Update(entity);
                }
            }
            else
            {
                entityList[entity.BackHash].Update(entity);
            }
        }
    }
}