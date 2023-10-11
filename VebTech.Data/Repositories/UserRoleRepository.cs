using Microsoft.EntityFrameworkCore;
using VebTech.Data.Contexts;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;

namespace VebTech.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddUserRole(Guid userId, Guid roleId)
        {
            var isExists = await _db.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (isExists)
            {
                throw new Exception("Record already exists in the database");
            }
            var userRole = new UserRole { RoleId = roleId, UserId = userId };
            _db.UserRoles.Add(userRole);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsUserRoleExistsAsync(Guid userId, Guid roleId)
        {
            return await _db.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
    }
}
