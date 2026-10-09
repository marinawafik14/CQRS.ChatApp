using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Features.User.Request.Query
{
    public class GetUserInfoQuary : IRequest<List<string>>
    {
        public int UserId { get; set; }
    }
}
