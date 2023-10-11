using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VebTech.Core.Services.Interfaces;
using VebTech.Data.Entities;
using VebTech.Data.Repositories.Interfaces;
using VebTech.Model.Response;

namespace VebTech.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public TokenService(IRoleRepository roleRepository, IConfiguration configuration)
        {
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseModel> GenerateTokensAsync(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Secret")));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var roles = await _roleRepository.GetUserRolesAsync(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role.RoleName));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims);

            // Get expiration minutes from configuration
            var JwtTokenExpiration = double.Parse(_configuration.GetValue<string>("JWT:JwtTokenExpirationMinutes"));
            // Encode secrets

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration.GetValue<string>("JWT:Audience"),
                Issuer = _configuration.GetValue<string>("JWT:Issuer"),
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(JwtTokenExpiration),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessTokenRaw = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(accessTokenRaw);

            var response = new LoginResponseModel()
            {
                AccessToken = accessToken,
            };
            return response;
        }
    }
}
