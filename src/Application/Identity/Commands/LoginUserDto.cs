namespace Application.Identity.Commands
{
    public class LoginUserDto
    {
        public string Email { get;}
        public string Password { get;}
        public LoginUserDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
