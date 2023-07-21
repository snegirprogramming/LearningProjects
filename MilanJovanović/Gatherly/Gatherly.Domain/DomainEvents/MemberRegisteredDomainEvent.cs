using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.DomainEvents;

public sealed record MemberRegisteredDomainEvent(Guid Id, Guid MemberId) : DomainEvent(Id);