using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Validations.OrderItem;

namespace ModernStore.Domain.Validations.Order
{
    public class RegisterOrderItemValidation : OrderItemValidation<RegisterOrderItemCommand>
    {
        public RegisterOrderItemValidation()
        {
            ValidateQuantity();
        }
    }
}
