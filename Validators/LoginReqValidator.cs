using FluentValidation;

namespace NZWalkTutorial.Validators
{
    public class LoginReqValidator : AbstractValidator<DTO.LoginReq>
    {
        public LoginReqValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
