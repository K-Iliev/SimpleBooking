using System.Threading.Tasks;
using Application.Common;
using Application.Identity.Commands;

namespace Application.Identity
{
    public interface IIdentity
    {
        Task<Result<IUser>> Register(CreateUserDto userInput);
        Task<Result<LoginSuccessDto>> Login(LoginUserDto userInput);
    }
}
