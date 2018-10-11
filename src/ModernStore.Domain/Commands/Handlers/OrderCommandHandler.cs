using FluentValidator;
using MediatR;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Events;
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
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            Bus = bus;
        }
        
        public Task Handle(RegisterOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var customer = _customerRepository.Get(message.Customer);

            var order = new Order(customer, message.Discount, message.DeliveryFee);

            foreach (var item in message.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity, product.Price));
            }

            _orderRepository.Save(order);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name.FirstName, customer.Email.Address, customer.BirthDate));
            }

            return Task.CompletedTask;
        }
    }
}
