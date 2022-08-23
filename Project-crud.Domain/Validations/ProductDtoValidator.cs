using FluentValidation;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Domain.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            ValidateCode();
            ValidateDescription();
            ValidateQuantityStock();
            ValidateValue();
        }

        private void ValidateCode()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado");
        }

        private void ValidateDescription()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descricao deve ser informado");
        }

        private void ValidateQuantityStock()
        {
            RuleFor(x => x.QuantityStock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantidade em estoque deve ser informado");

            RuleFor(x => x.QuantityStock)
                .GreaterThan(0)
                .WithMessage("Quantidade em estoque deve ser maior que 0");
        }

        private void ValidateValue()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .WithMessage("Valor deve ser informado");

            RuleFor(x => x.Value)
                .GreaterThan(0)
                .WithMessage("Valor deve ser maior que 0");
        }
    }
}
