using VebTech.Data.Entities;
using VebTech.Model.Response;

namespace VebTech.Core.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<LoginResponseModel> GenerateTokensAsync(User user);
        
    }
}
