using System;
using System.Data;

namespace EntityLib.lib
{
    [Serializable]
    public abstract class Entity
    {
        private int id;

        private int time;

        private int backHash;

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