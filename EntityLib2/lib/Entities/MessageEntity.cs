using System;

namespace EntityLib.lib.Entities
{
    [Serializable]
    public class MessageEntity: Entity
    {
        public string message;
        public string objectName = "MessageEntity";

        public override void Update(Entity entity)
        {
            entity = (MessageEntity) entity;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }
    }
}