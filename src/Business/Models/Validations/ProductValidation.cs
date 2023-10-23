using FluentValidation;

namespace Business.Models.Validations
{
    internal class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.Description).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
               .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}

  
    
