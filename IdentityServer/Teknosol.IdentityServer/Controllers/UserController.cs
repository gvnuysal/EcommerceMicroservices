using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; 
using Teknosol.IdentityServer.Dtos;
using Teknosol.IdentityServer.Models;
using Teknosol.Shared.Dtos;

namespace Teknosol.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignupAsync(SignupDto signupDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
                PhoneNumber = "0123456789"
            };
            
            var result = await _userManager.CreateAsync(user, signupDto.Password);
            
            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 404));
            }

            return Ok(Response<NoContent>.Success(204));
        }
    }
}