using Microsoft.VisualBasic;
using VebTech.Core.Services.Interfaces;
using VebTech.Data.Repositories.Interfaces;
using VebTech.Model.Request;

namespace VebTech.Core.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task AddUserRoleAsync(AddUserRoleRequstModel requstModel)
        {
            var isUserRoleExists = await _userRoleRepository.IsUserRoleExistsAsync(requstModel.UserId, requstModel.RoleId);
            if (isUserRoleExists)
            {
                throw new Exception("User is already has this role");
            }
            await _userRoleRepository.AddUserRole(requstModel.UserId, requstModel.RoleId);
        }
    }
}
