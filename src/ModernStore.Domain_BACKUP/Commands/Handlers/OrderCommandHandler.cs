using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable,
        ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderCommandHandler(
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository
            )
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);

            var order = new Order(customer, command.Discount, command.DeliveryFee);

            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity, product.Price));
            }

            AddNotifications(order.Notifications);

            if (Valid)
                _orderRepository.Save(order);

            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
