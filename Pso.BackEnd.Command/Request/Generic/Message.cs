using System;

namespace Pso.BackEnd.Command.Request.Generic
{
    public class Message
    {
        public DateTime DateCreated { get; protected set; }
        public string MessageId { get; protected set; }

        public Message()
        {
            DateCreated = DateTime.UtcNow;
            MessageId = Guid.NewGuid().ToString();
        }
    }
}
