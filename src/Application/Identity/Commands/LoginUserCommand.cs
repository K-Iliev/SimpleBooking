using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.Identity.Commands
{
    public class LoginUserCommand :  IRequest<Result<LoginSuccessDto>>
    {
        public string  Email { get; set; }
        public string Password { get; set; }
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginSuccessDto>>
        {
            private readonly IIdentity _identityService;
            public LoginUserCommandHandler(IIdentity identityService)
            {
                this._identityService = identityService;
            }
            public async Task<Result<LoginSuccessDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var result = await this._identityService.Login(new LoginUserDto(request.Email, request.Password));
                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                return result.Data;
            }
        }
    }
}
