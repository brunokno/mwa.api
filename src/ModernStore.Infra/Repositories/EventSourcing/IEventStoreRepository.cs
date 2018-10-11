using ModernStore.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace ModernStore.Infra.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregatedId);
    }
}
