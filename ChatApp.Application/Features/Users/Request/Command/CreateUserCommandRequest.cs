using ChatApp.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Features.Users.Request.Command
{
    public class CreateUserCommandRequest : IRequest<BaseCommonResponse>
    {

      public CreateUserDto createUserDto { get; set; } 



    }
}
