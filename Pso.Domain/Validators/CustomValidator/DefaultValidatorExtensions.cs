using FluentValidation;

namespace Pso.Domain.Validators.CustomValidator
{
    public static class DefaultValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> IsValidCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator());
        }
    }
}