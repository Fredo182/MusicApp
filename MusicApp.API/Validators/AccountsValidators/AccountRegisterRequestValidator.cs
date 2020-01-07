using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.AccountsRequests;

namespace MusicApp.API.Validators.AccountsValidators
{
    public class AccountRegisterRequestValidator : AbstractValidator<AccountRegisterRequest>
    {
        public AccountRegisterRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}
