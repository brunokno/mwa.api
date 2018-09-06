using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class OrderItem:Entity
    {
        public OrderItem(){}

        public OrderItem(Product product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;

            AddNotifications(new ValidationContract()
                .IsGreaterThan(Quantity, 1, "Quantity", $"Não temos tantos {Product.Title}(s) em estoque")
                .IsGreaterThan(Quantity, Product.QuantityOnHand, "Quantity", $"Não temos tantos {Product.Title}(s) em estoque")
                );

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
