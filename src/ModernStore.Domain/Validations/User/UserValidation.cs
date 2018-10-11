using FluentValidation;
using ModernStore.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Validations.User
{
    public class UserValidation<T>: AbstractValidator<T> where T : AuthenticateUserCommand
    {
        protected void ValidatePassword()
        {
            //RuleFor(c => c.Password)
            //    .Equal(c => c.LastName)
            //    .WithMessage("As senhas não coincidem");
        }

    }
}
