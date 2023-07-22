namespace Gatherly.Application.Gatherings.Queries.GetGatheringById;

public sealed record GatheringResponse(
    Guid Id,
    string Name,
    string? Location,
    string Creator,
    List<AttendeeResponse> Attendees,
    List<InvitationResponse> Invitations);