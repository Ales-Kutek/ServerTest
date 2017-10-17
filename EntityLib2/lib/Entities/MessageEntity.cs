using System;

namespace EntityLib.lib.Entities
{
    [Serializable]
    public class MessageEntity: Entity
    {
        public string message;
        public string objectName = "MessageEntity";

        public string Message
        {
            get => message;
            set => message = value;
        }
    }
}