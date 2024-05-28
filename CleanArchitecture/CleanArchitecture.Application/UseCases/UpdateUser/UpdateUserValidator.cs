using FluentValidation;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio")
                .MaximumLength(50).EmailAddress().WithMessage("Email precisa ter no máximo 50 caracteres");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MinimumLength(3).WithMessage("Nome precisa ter no minimo 3 caracteres")
                .MaximumLength(50).WithMessage("Nome não pode ter mais de 50 caracteres");
        }
    }
}
