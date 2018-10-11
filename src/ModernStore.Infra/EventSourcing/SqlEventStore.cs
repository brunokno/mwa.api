using ModernStore.Domain.Core.Events;
using ModernStore.Domain.Interfaces;
using ModernStore.Infra.Repositories.EventSourcing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository
            //, IUser user
            )
        {
            _eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Api" //_user.Name
                );

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
