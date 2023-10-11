using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Serilog;
using VebTech.Core.Exceptions;
using VebTech.Core.Services.Interfaces;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;
using VebTech.Model.Request;
using VebTech.Model.Response;

namespace VebTech.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ITokenService _tokenService;
        private readonly IValidator<SignUpRequestModel> _signUpValidator;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, ITokenService tokenService, IValidator<SignUpRequestModel> signUpValidator, IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _tokenService = tokenService;
            _signUpValidator = signUpValidator;
            _mapper = mapper;
        }

        public async Task<Guid> SignUpAsync(SignUpRequestModel requestModel)
        {
            ValidationResult validationResult = await _signUpValidator.ValidateAsync(requestModel);
            
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.ToString());
            }

            var user = _mapper.Map<User>(requestModel);
            
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);
            var userId = await _userRepository.AddUserAsync(user);

            foreach(var roleId in requestModel.RoleIds)
            {
                await _userRoleRepository.AddUserRole(userId, roleId);
            }

            return userId;
        }

        public async Task<LoginResponseModel> AuthenticateAsync(LoginRequestModel requestModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(requestModel.Email);
            if (user == null)
            {
                Log.Information($"User with email {requestModel.Email} not found");
                throw new UserNotFoundException();
            }
            var check = BCrypt.Net.BCrypt.Verify(requestModel.Password, user.PasswordHash);

            if (!check)
            {
                throw new Exception("Invalid Email or password");
            }

            return await _tokenService.GenerateTokensAsync(user); ;
        }
    }
}
