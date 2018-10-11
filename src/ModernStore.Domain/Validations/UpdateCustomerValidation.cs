using ModernStore.Domain.Commands.Inputs;

namespace ModernStore.Domain.Validations
{
    public class UpdateCustomerValidation :CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
