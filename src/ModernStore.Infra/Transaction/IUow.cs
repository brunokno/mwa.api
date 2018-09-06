using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.Transaction
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
