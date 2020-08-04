namespace Pso.Domain.Core
{
    public class ResultCommand
    {
        public static ResultCommand Ok = new ResultCommand();
    }

    public class ResultCommand<TResponse> : ResultCommand
    {
        public TResponse Data { get; }
        public ResultCommand() { }
        public ResultCommand(TResponse data)
        {
            Data = data;
        }
    }
}