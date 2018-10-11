using FluentValidator.Validation;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class Order:Entity
    {
        private readonly IList<OrderItem> _items;

        public Order(){}

        public Order(Customer customer, decimal discount, decimal deliveryFee)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.Created;
            Discount = discount;
            DeliveryFee = deliveryFee;

            _items = new List<OrderItem>();

            //AddNotifications(new ValidationContract()
            //    .IsGreaterThan(DeliveryFee, 0, "DeliveryFee", "Taxa de entrega não pode ser negativo")
            //    .IsGreaterThan(Discount, 0, "Discount", "Desconto não pode ser negativo")
            //    );
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items => _items.ToArray();
        public decimal Discount { get; private set; }
        public decimal DeliveryFee { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            //AddNotifications(item.Notifications);
            //if (item.Valid)
                _items.Add(item);
        }
    }
}
