using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Teknosol.IdentityServer.Application.Contract.Users;
using Teknosol.Shared.Dtos;

namespace Teknosol.IdentityServer.Application.Users
{
    public class SignupAppService : ISignupAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SignupAppService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public virtual async Task<SignupDto> SignupAsync(SignupCreateDto signupDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email
            }; 
            var users= await _userManager.CreateAsync(user, signupDto.Password);
           

            
        }
    }
}