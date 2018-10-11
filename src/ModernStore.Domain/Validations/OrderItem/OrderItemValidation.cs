using FluentValidation;
using ModernStore.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Validations.OrderItem
{
    public abstract class OrderItemValidation<T>: AbstractValidator<T> where T : RegisterOrderItemCommand
    {
        protected void ValidateQuantity()
        {
            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("Por favor, informe uma quantidade")
                .LessThan(1).WithMessage("Não é permitida quantidade menor ou igual a zero.") ;
        }
    }
}
