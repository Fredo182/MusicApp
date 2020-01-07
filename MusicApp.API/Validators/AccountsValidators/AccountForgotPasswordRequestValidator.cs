using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;

namespace MusicApp.API.Validators.AccountsValidators
{
    public class AccountForgotPasswordRequestValidator : AbstractValidator<AccountForgotPasswordRequest>
    {
        public AccountForgotPasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);
        }
    }
}
