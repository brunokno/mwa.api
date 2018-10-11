using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        Customer GetByEmail(string email);
        Customer Get(string username);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
