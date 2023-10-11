using VebTech.Data.Entities;

namespace VebTech.Data.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId);
    }
}
