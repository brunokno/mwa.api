using ModernStore.Domain.Commands.Inputs;

namespace ModernStore.Domain.Validations
{
    public class RemoveCustomerValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerValidation()
        {
            ValidateId();
        }
    }
}
