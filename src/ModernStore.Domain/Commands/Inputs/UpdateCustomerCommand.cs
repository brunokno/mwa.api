using ModernStore.Domain.Validations;
using System;

namespace ModernStore.Domain.Commands.Inputs
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(
            Guid id,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            string phone,
            string cellPhone,
            string endereco,
            string numero,
            string complemento,
            string cidade,
            string bairro,
            string estado,
            string inscricaoEstadual,
            string companyName
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            CellPhone = cellPhone;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Bairro = bairro;
            Estado = estado;
            InscricaoEstadual = inscricaoEstadual;
            CompanyName = companyName;
        }
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

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
