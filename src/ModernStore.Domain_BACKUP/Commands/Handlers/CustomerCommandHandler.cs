﻿using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
            IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "CPF já cadastrado");
                return null;
            }

            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            if (!Valid)
                return null;

            _customerRepository.Save(customer);

            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                EmailTemplates.WelcomeEmailTitle,
                EmailTemplates.WelcomeEmailBody);

            return new RegisterCustomerCommandResult(customer.Id, customer.Name.FirstName);
        }
    }
}
