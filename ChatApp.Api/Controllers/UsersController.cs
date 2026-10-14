using ChatApp.Application.Dtos.Users;
using ChatApp.Application.Features.User.Request.Command;
using ChatApp.Application.Features.User.Request.Query;
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
            GetUserInfoQuary query = new GetUserInfoQuary { UserId =2 };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create([FromForm] CreateUserDto userDto)
        {
          
            var result = await _mediator.Send(new CreateUserCommandRequest { createUserDto = userDto });
            return result.IsSuccess == true ? Ok(result) : BadRequest(result);
        }
    }
}
