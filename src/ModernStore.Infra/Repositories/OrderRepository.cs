using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ModernStoreDataContext _context;

        public OrderRepository(ModernStoreDataContext context)
            :base(context)
        {
        }

        public void Save(Order order)
        {
            DbSet.Add(order);
        }
    }
}
