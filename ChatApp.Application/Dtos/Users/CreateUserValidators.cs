using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Dtos.Users
{
    public class CreateUserValidators : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidators()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(50).WithMessage("UserName cannot exceed 50 characters.");

            RuleFor( x=> x.Email).NotEmpty().NotNull().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone number is required.")
                .Matches(@"^\+?(\d{1,3})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,4})?[-.\s]?(\d{1,9})$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.City).NotEmpty().NotNull().WithMessage("City is required.");

        }

    }
}
