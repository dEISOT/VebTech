using FluentValidation;
using VebTech.Data.Repositories.Interfaces;
using VebTech.Model.Request;

namespace VebTech.Core.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpRequestModel>
    {
       
        public SignUpValidator(IUserRepository userRepository)
        {
            RuleFor(user => user.Name).NotEmpty().MinimumLength(2);
            RuleFor(user => user.Email).EmailAddress().NotEmpty().NotNull().MustAsync(async (email, _) => 
            {
                return !await userRepository.UserExistsAsync(email);
            }).WithMessage("Email must be unique.");
            RuleFor(user => user.Age).InclusiveBetween(18, 60).NotNull();
            RuleFor(user => user.RoleIds).NotEmpty();
        }

        
    }
}
