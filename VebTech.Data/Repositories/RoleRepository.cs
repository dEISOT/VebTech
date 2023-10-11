using Microsoft.EntityFrameworkCore;
using VebTech.Data.Contexts;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;

namespace VebTech.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid userId)
        {
            return await _db.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role)
            .ToListAsync();
        }
    }
}
