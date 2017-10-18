using System;

namespace EntityLib.lib.Entities
{
    [Serializable]
    public class MessageEntity: Entity
    {
        public string message;

        public MessageEntity(Owner owner) : base(owner)
        {
        }

        public string Message
        {
            get => message;
            set => message = value;
        }
    }
}