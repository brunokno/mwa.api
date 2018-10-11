using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Commands;
using ModernStore.Domain.Core.Events;

namespace ModernStore.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(
            IMediator mediator,
            IEventStore eventStore
            )
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

    }
}
