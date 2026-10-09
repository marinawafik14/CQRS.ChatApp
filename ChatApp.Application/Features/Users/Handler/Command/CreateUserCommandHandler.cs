using ChatApp.Application.Dtos.Users;
using ChatApp.Application.Features.User.Request.Command;
using ChatApp.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
namespace ChatApp.Application.Features.User.Handler.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseCommonResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ChatApp.Domain.Entities.User> _userManager;
        public CreateUserCommandHandler(IMapper mapper, UserManager<ChatApp.Domain.Entities.User> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }
        public async Task<BaseCommonResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommonResponse();
            var validator = new CreateUserValidators() ;
            var resultValidation = await validator.ValidateAsync(request.createUserDto);

         if (!resultValidation.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Validation failed";
                response.Id = 0;
                response.Errors = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();
            }
           var userEntity = _mapper.Map<ChatApp.Domain.Entities.User>(request.createUserDto);
          var createUserResult = await _userManager.CreateAsync(userEntity, request.createUserDto.Password);
            if (!createUserResult.Succeeded)
            {
                response.IsSuccess = false;
                response.Message = "Validation failed";
                response.Id = 0;
                response.Errors = createUserResult.Errors.Select(e => e.Description).ToList();
            }
                response.IsSuccess = true;
                response.Message = "User created successfully";
                response.Id = userEntity.Id;
                
         
            return response;
        }
    }
}
