using MediatR;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Events;
using ModernStore.Domain.Interfaces;
using ModernStore.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterCustomerCommand>,
        IRequestHandler<UpdateCustomerCommand>,
        IRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public Task Handle(RegisterCustomerCommand message, CancellationToken cancellationToken)
        {
            if(!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            if (_customerRepository.DocumentExists(message.Document))
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF já cadastrado"));
                return Task.CompletedTask;
            }

            var name = new Name(message.FirstName, message.LastName);
            var email = new Email(message.Email);
            var document = new Document(message.Document);
            var user = new User(message.Username, message.Password, message.ConfirmPassword);
            var customer = new Customer(
                name, 
                email, 
                document, 
                user,
                message.BirthDate, 
                Guid.NewGuid(),
                message.InscricaoEstadual,
                message.CompanyName,
                message.Phone,
                message.CellPhone,
                message.Endereco,
                message.Numero,
                message.Complemento,
                message.Cidade,
                message.Bairro,
                message.Estado
            );

            _customerRepository.Add(customer);

            //_emailService.Send(
            //    customer.Name.ToString(),
            //    customer.Email.Address,
            //    EmailTemplates.WelcomeEmailTitle,
            //    EmailTemplates.WelcomeEmailBody);
            
            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name.FirstName, customer.Email.Address, customer.BirthDate));
            }

            return Task.CompletedTask;
        }
        
        public Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var name = new Name(message.FirstName, message.LastName);
            var email = new Email(message.Email);
            var customer = new Customer(
                name, 
                email,
                null, 
                null, 
                message.BirthDate,
                message.InscricaoEstadual,
                message.CompanyName,
                message.Phone,
                message.CellPhone,
                message.Endereco,
                message.Numero,
                message.Complemento,
                message.Cidade,
                message.Bairro,
                message.Estado);

            var existingCustomer = _customerRepository.GetByEmail(customer.Email.Address);

            if (existingCustomer != null && existingCustomer.Id != message.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                    return Task.CompletedTask;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name.FirstName, customer.Email.Address, customer.BirthDate));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

    }
}
