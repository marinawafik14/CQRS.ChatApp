using ChatApp.Application.Dtos.Users;
using ChatApp.Application.Features.User.Request.Command;
using ChatApp.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities;
using AutoMapper;
namespace ChatApp.Application.Features.User.Handler.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseCommonResponse>
    {
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IMapper mapper)
        {
            this._mapper = mapper;
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
           var user = _mapper.Map<ChatApp.Domain.Entities.User>(request.createUserDto);
          
        }
    }
}
