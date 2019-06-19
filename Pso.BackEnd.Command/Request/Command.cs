using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Command.Request
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
