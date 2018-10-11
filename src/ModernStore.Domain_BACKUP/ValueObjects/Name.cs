using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(FirstName, "FirstName", "Nome é obrigatório")
                .HasMaxLen(FirstName, 60, "FirstName", "Tamanho máximo do campo é de 60 caracteres")
                .HasMinLen(FirstName, 3, "FirstName", "Tamanho mínimo do campo é de 3 caracteres")
                .IsNullOrEmpty(LastName, "LastName", "Nome é obrigatório")
                .HasMaxLen(LastName, 60, "LastName", "Tamanho máximo do campo é de 60 caracteres")
                .HasMinLen(LastName, 3, "LastName", "Tamanho mínimo do campo é de 3")
                );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}