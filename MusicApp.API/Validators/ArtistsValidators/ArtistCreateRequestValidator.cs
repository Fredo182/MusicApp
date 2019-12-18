using System;
using System.Collections.Generic;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;

namespace MusicApp.API.Validators.ArtistsValidators
{
    public class ArtistCreateRequestValidator : AbstractValidator<ArtistCreateRequest>
    {
        public ArtistCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }

    public class ArtistsCreateRequestValidator : AbstractValidator<IEnumerable<ArtistCreateRequest>>
    {
        public ArtistsCreateRequestValidator()
        {
            RuleForEach(x => x)
                .SetValidator(new ArtistCreateRequestValidator());
        }
    }
}
