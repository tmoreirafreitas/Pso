using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace Pso.Domain.Validators.CustomValidator
{
    public abstract class DocumentoBaseValidator : PropertyValidator, IDocumentoPropertyValidator
    {
        private readonly int _validLength;
        protected abstract int[] FirstMultiplierCollection { get; }
        protected abstract int[] SecondMultiplierCollection { get; }

        protected DocumentoBaseValidator(int validLength, string errorMessage) : base(errorMessage)
        {
            _validLength = validLength;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var value = context.PropertyValue as string ?? string.Empty;
            value = Regex.Replace(value, "[^0-9]", "");

            if (IsValidLength(value) || AllDigitsAreEqual(value) || context.PropertyValue == null) return false;

            var cpf = value.Select(x => (int)char.GetNumericValue(x)).ToArray();
            var digits = GetDigits(cpf);

            return value.EndsWith(digits);
        }

        private static bool AllDigitsAreEqual(string value) => value.All(x => x == value.FirstOrDefault());
        private bool IsValidLength(string value) => !string.IsNullOrWhiteSpace(value) && value.Length != _validLength;

        private string GetDigits(int[] cpf)
        {
            var first = CalculateValue(FirstMultiplierCollection, cpf);
            var second = CalculateValue(SecondMultiplierCollection, cpf);
            return $"{CalculateDigit(first)}{CalculateDigit(second)}";
        }

        private static int CalculateValue(int[] weight, int[] numbers)
        {
            return weight.Select((t, i) => t * numbers[i]).Sum();
        }

        private static int CalculateDigit(int sum)
        {
            var modResult = (sum % 11);
            return modResult < 2 ? 0 : 11 - modResult;
        }
    }
}