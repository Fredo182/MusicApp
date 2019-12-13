using System;
using System.Collections.Generic;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;

namespace MusicApp.API.Validators.ArtistsValidators
{
    public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequest>
    {
        public CreateArtistRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }

    public class CreateArtistsRequestValidator : AbstractValidator<IEnumerable<CreateArtistRequest>>
    {
        public CreateArtistsRequestValidator()
        {
            RuleForEach(x => x)
                .SetValidator(new CreateArtistRequestValidator());
        }
    }
}
