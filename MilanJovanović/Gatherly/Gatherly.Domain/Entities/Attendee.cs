namespace Gatherly.Domain.Entities;

public class Attendee
{
    internal Attendee(Invitation invitation)
    {
        GatheringId = invitation.GatheringId;
        MemberId = invitation.MemberId;
        CraeteOnUtc = DateTime.UtcNow;
    }

    public Guid GatheringId { get; private set; }
    public Guid MemberId { get; private set; }
    public DateTime CraeteOnUtc { get; private set; }
}
