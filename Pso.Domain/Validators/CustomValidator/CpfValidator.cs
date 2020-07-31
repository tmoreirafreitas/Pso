namespace Pso.Domain.Validators.CustomValidator
{
    public class CpfValidator : DocumentoBaseValidator
    {
        protected override int[] FirstMultiplierCollection => new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        protected override int[] SecondMultiplierCollection => new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        internal CpfValidator(int validLength, string errorMessage) : base(validLength, errorMessage)
        { }

        public CpfValidator(string errorMessage) : this(11, errorMessage)
        { }

        public CpfValidator() : this("O CPF é inválido!")
        { }
    }
}