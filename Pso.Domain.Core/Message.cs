using System;

namespace Pso.Domain.Core
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
