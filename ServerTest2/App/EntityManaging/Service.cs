using System.Runtime.InteropServices;
using EntityLib.lib;

namespace ServerTest2.App.EntityManaging
{
    public abstract class Service
    {
        protected EntityManager _entityManager;

        protected Service(EntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public abstract bool ResolveNew(Entity entity);

        public abstract void Update(Entity serverEntity, Entity clientEntity);
    }
}