using ModernStore.Domain.Validations;
using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterCustomerCommand : CustomerCommand
    {
        public RegisterCustomerCommand(
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            string document,
            string username,
            string password,
            string confirmPassword,
            string inscricaoEstadual,
            string companyName,
            string phone,
            string cellPhone,
            string endereco,
            string numero,
            string complemento,
            string cidade,
            string bairro,
            string estado
            )
        {
            FirstName = FirstName;
            LastName = LastName;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            InscricaoEstadual = inscricaoEstadual;
            CompanyName = companyName;
            Phone = phone;
            CellPhone = cellPhone;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Bairro = bairro;
            Estado = estado;
        }

        public string Document { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
