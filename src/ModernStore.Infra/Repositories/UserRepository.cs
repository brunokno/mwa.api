using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(string username)
        {
            return new User("brunokno@gmail.com", "123456", "123456");
        }
    }
}
