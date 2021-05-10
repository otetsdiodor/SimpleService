using SimpleService.Core.Exceptions;
using SimpleService.Core.Models;
using SimpleService.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace SimpleService.Core.Services
{
    public class UserAuthService : IUserAuthService
    {
        public Task<User> AuthentificateAsync(string name, string password)
        {
            return Task.Run(() =>
            {
                if (name != "test" || password != "test")
                {
                    throw new UnauthorizedException("Wrong name or password");
                }

                return new User(name);
            });
        }
    }
}
