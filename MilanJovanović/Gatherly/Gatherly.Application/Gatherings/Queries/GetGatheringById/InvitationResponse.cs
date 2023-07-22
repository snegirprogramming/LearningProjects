using Gatherly.Domain.Enums;

namespace Gatherly.Application.Gatherings.Queries.GetGatheringById;

public sealed record InvitationResponse(Guid Id, InvitationStatus Status);