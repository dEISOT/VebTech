using VebTech.Model.Request;
using VebTech.Model.Response;

namespace VebTech.Core.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseModel> AuthenticateAsync(LoginRequestModel requestModel);
        public Task<Guid> SignUpAsync(SignUpRequestModel requestModel);
    }
}
