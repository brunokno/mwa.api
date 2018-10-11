using FluentValidator;
using MediatR;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.Interfaces;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernStore.Domain.Commands.Handlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public UserCommandHandler(
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
             : base(uow, bus, notifications)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public Task Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            var user = _userRepository.GetUser(command.Username);
            var authenticated = user.Authenticate(command.Username, command.Password);

            //AddNotifications(user.Notifications);

            if (!authenticated)
                return null;

            //return new AuthenticateUserCommandResult(
            //    "32165478902",
            //     "brunokno@gmail.com",
            //     "bruno",
            //     "132456",
            //     "brunokno@gmail.com"
            //    );

            return Task.CompletedTask;
        }
    }
}
