using VebTech.Data.Contexts;
using VebTech.Data.Entities;

namespace VebTech.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(Guid Id);

    }
}
