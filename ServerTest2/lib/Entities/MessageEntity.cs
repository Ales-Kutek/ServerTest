using System;

namespace Lib.Entities
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