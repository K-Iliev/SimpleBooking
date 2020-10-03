namespace Application.Identity.Commands
{
    public class CreateUserDto
    {
        public string Email { get; }
        public string Password { get;  }

        public CreateUserDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
