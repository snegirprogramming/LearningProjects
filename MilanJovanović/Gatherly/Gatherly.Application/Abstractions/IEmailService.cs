using Gatherly.Domain.Entities;

namespace Gatherly.Application.Abstractions;

internal interface IEmailService
{
    Task SendInvitationSentEmailAsync(Member member, Gathering gathering);
    Task SendInvitationAcceptedEmailAsync(Gathering gathering, CancellationToken cancellationToken);
}
