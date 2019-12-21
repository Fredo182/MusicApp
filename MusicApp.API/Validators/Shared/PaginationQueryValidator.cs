//using System;
//using FluentValidation;
//using MusicApp.API.Contracts.V1.Requests.Queries.Shared;

//namespace MusicApp.API.Validators.Shared
//{
//    public class PaginationQueryValidator : AbstractValidator<PaginationQuery>
//    {
//        public PaginationQueryValidator()
//        {
//            RuleFor(x => x.PageNumber)
//                .GreaterThanOrEqualTo(1)
//                .NotNull().When(x => (x.PageSize != null));

//            RuleFor(x => x.PageSize)
//                .GreaterThanOrEqualTo(1)
//                .NotNull().When(x => (x.PageNumber != null));
//        }
//    }
//}
