using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.DomainEvents;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent(Guid id) => Id = id;

    public Guid Id { get; set; }
}
