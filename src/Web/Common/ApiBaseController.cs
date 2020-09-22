using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Common
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext
                  .RequestServices
                  .GetService<IMediator>();
    }
}
