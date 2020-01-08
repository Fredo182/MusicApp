using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;

namespace MusicApp.API.Validators.AccountsValidators
{
    public class AccountChangePasswordRequestValidator : AbstractValidator<AccountChangePasswordRequest>
    {
        public AccountChangePasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}
