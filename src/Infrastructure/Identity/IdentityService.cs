using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Identity;
using Application.Identity.Commands;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public IdentityService(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this._userManager = userManager;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<LoginSuccessDto>> Login(LoginUserDto userInput)
        {
            var user = await this._userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this._userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this._jwtTokenGenerator.GenerateToken(user);

            return new LoginSuccessDto(user.Id, token);
        }

        public async Task<Result<IUser>> Register(CreateUserDto userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this._userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }

    }
}
