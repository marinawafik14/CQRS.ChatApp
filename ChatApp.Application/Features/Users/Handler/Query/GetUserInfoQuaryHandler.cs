using AutoMapper;
using ChatApp.Application.Dtos.Users;
using ChatApp.Application.Features.User.Request.Query;
using ChatApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Features.User.Handler.Query
{
    public class GetUserInfoQuaryHandler : IRequestHandler<GetUserInfoQuary, UserInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserInfoQuaryHandler(IMapper mapper , IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

       public async Task <UserInfoDto> Handle(GetUserInfoQuary request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            return _mapper.Map<UserInfoDto>(user); 
        }
    }
}
