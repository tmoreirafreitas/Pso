using FluentValidation;
using FluentValidation.Results;

namespace Pso.Domain.Core
{
    public class Command<TEntity> : Message, ICommand<ResultCommand<TEntity>> where TEntity : Entities.Entity
    {
        public string Name { get; }
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

        public Command()
        {
            Name = GetType().Name;
        }

        public override string ToString()
        {
            var info = $"CommandName:{Name}\r\nID: {MessageId}\r\n Created: {DateCreated}";
            return info;
        }
    }
}