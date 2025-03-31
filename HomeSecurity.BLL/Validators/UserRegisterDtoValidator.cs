using FluentValidation;
using HomeSecurity.BLL.DTOs.Users;

namespace HomeSecurity.BLL.Validators;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обов'язковий")
            .EmailAddress().WithMessage("Не вірний email");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ім'я є обов'язковим.")
            .MaximumLength(100).WithMessage("Ім'я має бути менше 100 символів.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Прізвище є обов'язковим.")
            .MaximumLength(100).WithMessage("Прізвище має бути менше 100 символів.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обов'язковий")
            .MinimumLength(6).WithMessage("Пароль має бути більшим ніж 6 символів");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Паролі не співпадають");
    }
}