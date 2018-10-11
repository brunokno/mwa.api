using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ModernStoreDataContext context)
            :base(context)
        {

        }

        public User GetUser(string username)
        {
            return new User("brunokno@gmail.com", "123456", "123456");
        }
    }
}
