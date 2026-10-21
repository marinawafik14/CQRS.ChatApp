using ChatApp.Application.Dtos.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Features.User.Request.Query
{
    public class GetUserInfoQuary : IRequest<UserInfoDto>
    {
        public int UserId { get; set; }
    }
}
