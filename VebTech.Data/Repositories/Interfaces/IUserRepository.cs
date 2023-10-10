using VebTech.Data.Contexts;
using VebTech.Data.Entities;

namespace VebTech.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(Guid Id);
        public Task<bool> UpdateUserAsync(User user);
        public Task DeleteUserAsync(Guid Id);
        public Task<Guid> AddUserAsync(User user);


    }
}
