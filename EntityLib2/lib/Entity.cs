using System;

namespace EntityLib.lib
{
    [Serializable]
    public abstract class Entity
    {
        private int id;

        private int time;

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
    }
}