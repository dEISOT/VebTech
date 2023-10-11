using VebTech.Model.Request;

namespace VebTech.Core.Services.Interfaces
{
    public interface IUserRoleService
    {
        public Task AddUserRoleAsync(AddUserRoleRequstModel requstModel);
    }
}
