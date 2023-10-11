using AutoMapper;
using Microsoft.VisualBasic;
using Serilog;
using VebTech.Core.DTO;
using VebTech.Core.Exceptions;
using VebTech.Core.Services.Interfaces;
using VebTech.Data.Repositories.Interfaces;
using VebTech.Model.Response;

namespace VebTech.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public Task<Guid> AddUserAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseModel> GetUserByIdAsync(Guid Id)
        {
            var user = _mapper.Map<UserResponseModel>(await _userRepository.GetUserByIdAsync(Id));
            user.Roles = _mapper.Map(await _roleRepository.GetUserRolesAsync(Id), user.Roles);
            
            if (user == null)
            {
                Log.Information($"user with order id {Id} not found");
                throw new UserNotFoundException();
            }
            
            return user;
        }

        public Task<bool> UpdateUserAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
