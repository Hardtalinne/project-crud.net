using FluentValidation;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Domain.Validations
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            ValidateCode();
        }

        private void ValidateCode()
        {
            RuleFor(x => x.CodeProducts)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ao menos um codigo de produto deve ser informado");
        }
    }
}
