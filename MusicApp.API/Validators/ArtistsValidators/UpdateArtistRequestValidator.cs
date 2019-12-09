using System;
using FluentValidation;
using MusicApp.API.Contracts.V1.Requests.ArtistsRequests;

namespace MusicApp.API.Validators.ArtistsValidators
{
    public class UpdateArtistRequestValidator : AbstractValidator<UpdateArtistRequest>
    {
        public UpdateArtistRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
