using FluentValidation;
using ModernStore.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Validations.Order
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : RegisterOrderCommand
    {
        protected void ValidateDeliveryFee()
        {
            RuleFor(c => c.DeliveryFee)
                .LessThan(0).WithMessage("Taxa de entrega não pode ser negativo");
        }

        protected void ValidateDiscount()
        {
            RuleFor(c => c.Discount)
                .LessThan(0).WithMessage("Desconto não pode ser negativo");
        }
    }
}
