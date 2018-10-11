using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
