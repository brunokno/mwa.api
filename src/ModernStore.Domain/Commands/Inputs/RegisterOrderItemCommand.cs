using ModernStore.Domain.Core.Commands;
using ModernStore.Domain.Validations.Order;
using System;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterOrderItemCommand : Command
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
