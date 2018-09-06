using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Commands.Handlers
{
    public class UserCommandHandler : Notifiable, 
        ICommandHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserCommandHandler(
            IUserRepository userRepository,
            ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(AuthenticateUserCommand command)
        {
            var user = _userRepository.GetUser(command.Username);
            var authenticated = user.Authenticate(command.Username, command.Password);

            AddNotifications(user.Notifications);

            if (!authenticated)
                return null;

            return new AuthenticateUserCommandResult(
                "32165478902",
                 "brunokno@gmail.com",
                 "bruno",
                 "132456",
                 "brunokno@gmail.com"
                );
        }
    }
}
