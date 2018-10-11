using ModernStore.Domain.ValueObjects;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer:Entity
    {
        public Customer(){}

        public Customer(
            Name name, 
            Email email, 
            Document document, 
            User user, 
            DateTime? birthDate, 
            Guid id,
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
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            User = user;
            Id = id;
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

        public Customer(
            Name name, 
            Email email, 
            Document document, 
            User user, 
            DateTime? birthDate,
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
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            User = user;
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

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string CompanyName { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
    }
}
