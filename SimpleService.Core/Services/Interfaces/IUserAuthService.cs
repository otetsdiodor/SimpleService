using SimpleService.Core.Models;
using System.Threading.Tasks;

namespace SimpleService.Core.Services.Interfaces
{
    public interface IUserAuthService
    {
        public Task<User> AuthentificateAsync(string name, string password);
    }
}
