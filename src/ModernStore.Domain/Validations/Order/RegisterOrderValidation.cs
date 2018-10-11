using FluentValidation;
using ModernStore.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Validations.Order
{
    public  class RegisterOrderValidation:OrderValidation<RegisterOrderCommand>
    {
        public RegisterOrderValidation()
        {
            ValidateDeliveryFee();
            ValidateDiscount();
        }
    }
}
