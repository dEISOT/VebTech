using AutoMapper;
using Serilog;
using VebTech.Core.DTO;
using VebTech.Core.Exceptions;
using VebTech.Core.Services.Interfaces;
using VebTech.Data.Repositories.Interfaces;

namespace VebTech.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
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

        public async Task<UserDTO> GetUserByIdAsync(Guid Id)
        {
            var user = _mapper.Map<UserDTO>(await _userRepository.GetUserByIdAsync(Id));
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
