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
    }
}
