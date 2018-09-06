using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable {

        protected Email(){}
        
        public Email(string address)
        {
            Address = address;
            
            AddNotifications(new ValidationContract()
                .IsEmail(Address, "Address", "E-mail inválido"));
        }

        public string Address { get; private set; }
    }
}