using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Interfaces;
using ModernStore.Infra.Contexts;
using System;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ModernStoreDataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ModernStoreDataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
