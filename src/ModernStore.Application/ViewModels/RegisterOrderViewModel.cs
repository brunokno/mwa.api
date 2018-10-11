using ModernStore.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class RegisterOrderViewModel
    {
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
