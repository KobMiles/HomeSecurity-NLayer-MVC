using FluentValidation;
using HomeSecurity.BLL.DTOs.Users;

namespace HomeSecurity.BLL.Validators;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обов'язковий")
            .EmailAddress().WithMessage("Не вірний email");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обов'язковий")
            .MinimumLength(6).WithMessage("Пароль має бути більшим ніж 6 символів"); ;
    }
}