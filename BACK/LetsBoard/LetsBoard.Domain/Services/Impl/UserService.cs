using LetsAuth.Models.Models;
using LetsBoard.Domain.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LetsAuth.Domain.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            if(model.Username == _appSettings.Username && model.Password == _appSettings.Password)
            {
                var token = await GenerateJwtToken(model.Username);

                return new AuthenticateResponse(model.Username, token);
            }
            return null;            
        }

        private Task<string> GenerateJwtToken(string username)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            Task.Run(() =>
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("username", username) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                tcs.SetResult(tokenHandler.WriteToken(token));
            });

            return tcs.Task;
        }
    }
}
