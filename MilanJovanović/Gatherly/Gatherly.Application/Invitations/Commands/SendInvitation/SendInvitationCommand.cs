using Gatherly.Application.Abstractions.Messaging;

namespace Gatherly.Application.Invitations.Commands.SendInvitation;

public sealed record SendInvitationCommand(Guid MemberId, Guid GatheringId) : ICommand;