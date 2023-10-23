using Business.Models.Validations.Documents;
using FluentValidation;

namespace Business.Models.Validations
{
    internal class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation() {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2,100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.IdentityCard.Length).Equal(NifValidation.nifLenght)
                .WithMessage("O campo nif precisa ter {comparisonValue} caracteres e for fornecido {PropertyValue}");
            RuleFor(x => NifValidation.IsValidNIF(x.IdentityCard)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        }
    }
}
