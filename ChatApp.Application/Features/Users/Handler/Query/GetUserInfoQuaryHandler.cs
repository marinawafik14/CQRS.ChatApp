using ChatApp.Application.Features.User.Request.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Features.User.Handler.Query
{
    public class GetUserInfoQuaryHandler : IRequestHandler<GetUserInfoQuary, List<string>>
    {
        private static readonly Dictionary<int, List<string>> FakeUserDb = new Dictionary<int, List<string>>()
       {
           {1, new List<string>() {"ahmed", "cairo"} },
           {2, new List<string>() {"ali", "mansoura"} }
       };

        async Task<List<string>> IRequestHandler<GetUserInfoQuary, List<string>>.Handle(GetUserInfoQuary request, CancellationToken cancellationToken)
        {
            if (FakeUserDb.TryGetValue(request.UserId ,out List<string>? value))
            {
                return await Task.FromResult(value);
            }

            return new List<string> { "user not found" };
        }
    }
}
