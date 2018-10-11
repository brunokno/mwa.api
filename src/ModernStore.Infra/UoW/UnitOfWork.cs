using ModernStore.Domain.Interfaces;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.UoW
{
    public class  UnitOfWork: IUnitOfWork
    {
        public readonly ModernStoreDataContext _context;

        public UnitOfWork(ModernStoreDataContext context)
        {
            _context = context;
        }

        bool IUnitOfWork.Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
