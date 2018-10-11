using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
            :base(context)
        {

        }

        public Product Get(Guid id)
        {
            return DbSet
                    //.AsNoTracking()
                    .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var resultBookList = new GetProductListCommandResult[] {
                new GetProductListCommandResult { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300",Title = "Fahrenheit 451 - part 2 for ex.", Description= "Mouse de alta performance para quem está buscando alto desempenho nos games!", Price =20m },
                new GetProductListCommandResult { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "Hundred years of Solitude",Description="Description de teste para exibição",Price=25m },
                new GetProductListCommandResult { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "1984 - part 2 for exemplo",Description="Description de teste para exibição", Price=37m },
                new GetProductListCommandResult { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "Delta of Venus - part 2 for ex",Description="Description de teste para exibição", Price=56m }
            };

            return resultBookList;
        }
    }
}
