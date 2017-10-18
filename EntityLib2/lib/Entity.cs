using System;
using System.Collections.Generic;
using System.Data;

namespace EntityLib.lib
{
    [Serializable]
    public abstract class Entity
    {
        private int id;

        private int time;

        private int backHash;

        private List<Action<Entity>> onUpdate = new List<Action<Entity>>();

        public void Update(Entity entity)
        {
            foreach (Action<Entity> ev in onUpdate)
            {
                ev(entity);
            }
        }

        public List<Action<Entity>> OnUpdate
        {
            get => onUpdate;
//            set => onUpdate = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Time
        {
            get => time;
            set => time = value;
        }

        public int BackHash
        {
            get => backHash;
            set => backHash = value;
        }
    }
}