using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        GetCustomerCommandResult Get(string username);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
