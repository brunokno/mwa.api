using System;
using FluentValidator;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity:Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; private set; }
    }
}