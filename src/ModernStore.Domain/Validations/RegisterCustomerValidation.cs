using ModernStore.Domain.Commands.Inputs;

namespace ModernStore.Domain.Validations
{
    public class RegisterCustomerValidation : CustomerValidation<RegisterCustomerCommand>
    {
        public RegisterCustomerValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
