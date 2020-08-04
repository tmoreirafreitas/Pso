namespace Pso.Domain.Core
{
    public class Command : Message, ICommand<ResultCommand>
    {
        public string Name => GetType().Name;
        public override string ToString()
        {
            var info = $"CommandName:{Name}\r\nID: {MessageId}\r\n Created: {DateCreated}";
            return info;
        }
    }
    public class Command<TEntity> : Message, ICommand<ResultCommand<TEntity>> where TEntity : Entities.Entity
    {
        public string Name => GetType().Name;
        public override string ToString()
        {
            var info = $"CommandName:{Name}\r\nID: {MessageId}\r\n Created: {DateCreated}";
            return info;
        }
    }
}