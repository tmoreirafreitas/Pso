using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.Generic
{
    public class Command<T> : Message where T : Entity
    {
        public string Name { get; private set; }
        public T Item { get; private set; }

        public Command(T item)
        {
            Name = GetType().Name;
            Item = item;
        }

        public override string ToString()
        {
            var info = $"CommandName:{Name}\r\nID: {MessageId}\r\n Created: {DateCreated}";
            return info;
        }
    }
}
