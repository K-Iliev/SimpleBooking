using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.Identity.Commands
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity _identityService;
            public CreateUserCommandHandler(IIdentity identityService)
            {
                this._identityService = identityService;
            }
            public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return await this._identityService.Register(new CreateUserDto(request.Email, request.Password));
            }
        }
    }
}
