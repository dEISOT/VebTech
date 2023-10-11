using FluentValidation;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;

namespace VebTech.Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserValidator() 
        {
            RuleFor(user => user.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(user => user.Name).NotEmpty().NotNull();
            RuleFor(user => user.Email).MustAsync(IsEmailUnique).WithMessage("Email must be unique.");
            RuleFor(user => user.Age).InclusiveBetween(18, 100).NotNull().WithMessage("Age must be between 18 and 100 (inclusive)");
            RuleFor(user => user.UserRoles).NotEmpty();
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken token)
        {
            bool isExistingUser = await _userRepository.UserExistsAsync(email);
            return !isExistingUser;
        }
    }
}
