using System.Threading.Tasks;

namespace Teknosol.IdentityServer.Application.Contract.Users
{
    public interface ISignupAppService
    {
        public Task<SignupDto> SignupAsync(SignupCreateDto signupDto);
    }
}