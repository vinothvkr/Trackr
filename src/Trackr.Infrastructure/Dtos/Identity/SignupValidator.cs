using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos.Identity
{
    public class SignupValidator : AbstractValidator<SignupDto>
    {
        public SignupValidator()
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.ConfirmPassword).Equal(m => m.Password);
        }
    }
}
