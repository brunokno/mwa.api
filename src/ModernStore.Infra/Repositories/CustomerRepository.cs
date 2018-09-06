using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
//using System.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context
                        .Customers
                        .Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context
                        .Customers
                        .Include(x => x.User)
                        .FirstOrDefault(x => x.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {
            return _context
                        .Customers
                        .Include(x => x.User)
                        .AsNoTracking()
                        .Select(x => new GetCustomerCommandResult
                        {
                            Name = x.Name.ToString(),
                            Document = x.Document.Number,
                            Active = x.User.Active,
                            Email = x.Email.Address,
                            Password = x.User.Password,
                            Username = x.User.Username
                        })
                        .FirstOrDefault(x => x.Username == username);

        }

        public Customer GetByUsername(string username)
        {
            return _context
                    .Customers
                    .FirstOrDefault(x => x.User.Username == username);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
