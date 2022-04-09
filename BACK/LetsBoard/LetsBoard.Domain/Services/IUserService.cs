using LetsAuth.Models.Models;
using System.Threading.Tasks;

namespace LetsAuth.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
