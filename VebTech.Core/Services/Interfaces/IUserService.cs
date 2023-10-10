using VebTech.Core.DTO;

namespace VebTech.Core.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserByIdAsync(Guid Id);
        public Task<bool> UpdateUserAsync(UserDTO user);
        public Task DeleteUserAsync(Guid Id);
        public Task<Guid> AddUserAsync(UserDTO user);
    }
}
