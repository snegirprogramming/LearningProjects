using Gatherly.Domain.Entities;

namespace Gatherly.Application.Abstractions;

internal interface IEmailService
{
    Task SendInvitationSentEmailAsync(Member member, Gathering gathering, CancellationToken cancellationToken);
    Task SendInvitationAcceptedEmailAsync(Gathering gathering, CancellationToken cancellationToken);
    Task SendWelcomeEmailAsync(Member member, CancellationToken cancellationToken);
}