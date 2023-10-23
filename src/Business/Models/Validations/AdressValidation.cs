using FluentValidation;

namespace Business.Models.Validations
{
    public class AdressValidation: AbstractValidator<Address>
    {
        public AdressValidation() {

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.District)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
              .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.ZipCode)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
              .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLenght} caracteres");

            RuleFor(x => x.City)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
              .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.State)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
              .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");
            
            RuleFor(x => x.State)
                  .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                  .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

        }
    }
}
