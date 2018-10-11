using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
//using System.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Interfaces;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
            : base(context)
        {
        }

        public bool DocumentExists(string document)
        {
            return DbSet
                        .Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return DbSet
                        .Include(x => x.User)
                        .FirstOrDefault(x => x.Id == id);
        }

        Customer ICustomerRepository.Get(string username)
        {
            return DbSet
            .Include(x => x.User)
            .AsNoTracking()
            .FirstOrDefault(x => x.User.Username == username);
        }

        public GetCustomerCommandResult Get(string username)
        {
            return DbSet
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
            return DbSet
                    .FirstOrDefault(x => x.User.Username == username);
        }

        public Customer GetByEmail(string email)
        {
            return DbSet
                    .FirstOrDefault(x => x.Email.Address == email);
        }

        public void Save(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            Db.Entry(customer).State = EntityState.Modified;
        }

    }
}
