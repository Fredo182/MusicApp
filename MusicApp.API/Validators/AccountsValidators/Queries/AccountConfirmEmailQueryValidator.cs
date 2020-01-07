using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.Queries;

namespace MusicApp.API.Validators.AccountsValidators.Queries
{
    public class AccountConfirmEmailQueryValidator : AbstractValidator<AccountConfirmEmailQuery>
    {
        public AccountConfirmEmailQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}
