using FluentValidation.Results;

namespace Pso.Domain.Core
{
    public class ResultCommand
    {
        public static ResultCommand Ok = new ResultCommand();
        public ValidationResult ValidationResult { get; set; }
        public ResultCommand()
        {
            ValidationResult = new ValidationResult();
        }
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