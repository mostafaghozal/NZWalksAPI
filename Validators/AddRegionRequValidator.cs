using FluentValidation;

namespace NZWalkTutorial.Validators
{

    public class AddRegionRequValidator : AbstractValidator<DTO.AddRegionReq>
    {
        public AddRegionRequValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);

        }
    }
}
