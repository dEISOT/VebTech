namespace VebTech.Data.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        public Task AddUserRole(Guid userId,Guid roleId);
        public Task<bool> IsUserRoleExistsAsync(Guid userId, Guid roleId);

    }
}
