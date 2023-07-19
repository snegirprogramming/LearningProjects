namespace Gatherly.Domain.Exceptions;

public sealed class GatheringInvitationsValidBeforeInHoursIsNullDomainException : DomainException
{
    public GatheringInvitationsValidBeforeInHoursIsNullDomainException(string message) : base(message)
    {
    }
}