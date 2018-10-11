using ModernStore.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand( Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
