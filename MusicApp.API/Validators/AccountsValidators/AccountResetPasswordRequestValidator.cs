using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;

namespace MusicApp.API.Validators.AccountsValidators
{
    public class AccountResetPasswordRequestValidator : AbstractValidator<AccountResetPasswordRequest>
    {
        public AccountResetPasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}
