using ModernStore.Domain.Core.Commands;
using ModernStore.Domain.Validations.Order;
using System;
using System.Collections.Generic;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterOrderCommand : Command
    {
        //O que eu preciso para gravar um pedido?
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
