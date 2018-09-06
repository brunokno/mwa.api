using System;
using System.Collections.Generic;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterOrderCommand : ICommand
    {
        //O que eu preciso para gravar um pedido?
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
