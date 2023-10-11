using VebTech.Core.DTO;
using VebTech.Model.Response;

namespace VebTech.Core.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponseModel> GetUserByIdAsync(Guid Id);
        public Task<bool> UpdateUserAsync(UserDTO user);
        public Task DeleteUserAsync(Guid Id);
        public Task<Guid> AddUserAsync(UserDTO user);
    }
}
