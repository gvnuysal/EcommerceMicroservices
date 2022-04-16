namespace Teknosol.IdentityServer.Application.Contract.Users
{
    public class SignupCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
    }
}