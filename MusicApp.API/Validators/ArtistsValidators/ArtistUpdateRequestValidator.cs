using System;
using System.Collections.Generic;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;

namespace MusicApp.API.Validators.ArtistsValidators
{
    public class ArtistUpdateRequestValidator : AbstractValidator<ArtistUpdateRequest>
    {
        public ArtistUpdateRequestValidator()
        {
            RuleFor(x => x.ArtistId)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

        }

        public class ArtistsUpdateRequestValidator : AbstractValidator<IEnumerable<ArtistUpdateRequest>>
        {
            public ArtistsUpdateRequestValidator()
            {
                RuleForEach(x => x)
                    .SetValidator(new ArtistUpdateRequestValidator());
            }
        }
    }
}
