using ChatApp.Application.Features.Users.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> Get()
        {
            GetUserInfoQuary query = new GetUserInfoQuary { UserId =1 };
            var result = await _mediator.Send(query);
            return Ok(result);

        }
    }
}
