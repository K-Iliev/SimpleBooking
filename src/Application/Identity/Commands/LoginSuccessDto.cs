namespace Application.Identity.Commands
{
    public class LoginSuccessDto
    {
        public string UserId { get; }
        public string Token { get; }

        public LoginSuccessDto(string userId, string token)
        {
            this.UserId = userId;
            this.Token = token;
        }
    }
}
