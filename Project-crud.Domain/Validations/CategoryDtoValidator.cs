using FluentValidation;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Domain.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            ValidateCode();
        }

        private void ValidateCode()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("A descrição da categoria deve ser informado");
        }
    }
}
