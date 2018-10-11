using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
