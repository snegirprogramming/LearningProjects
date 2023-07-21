using MediatR;

namespace Gatherly.Domain.Primitives;

public interface IDomainEvent : INotification
{
    Guid Id { get; set; }
}