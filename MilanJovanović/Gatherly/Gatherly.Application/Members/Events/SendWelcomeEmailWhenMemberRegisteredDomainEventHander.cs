using Gatherly.Application.Abstractions;
using Gatherly.Domain.DomainEvents;
using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using MediatR;

namespace Gatherly.Application.Members.Events;

internal sealed class SendWelcomeEmailWhenMemberRegisteredDomainEventHander
    : INotificationHandler<MemberRegisteredDomainEvent>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IEmailService _emailService;

    public SendWelcomeEmailWhenMemberRegisteredDomainEventHander(
        IMemberRepository memberRepository,
        IEmailService emailService)
    {
        _memberRepository = memberRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        MemberRegisteredDomainEvent notification,
        CancellationToken cancellationToken)
    {
        Member? member = await _memberRepository.GetByIdAsync(
            notification.Id,
            cancellationToken);

        if (member is null)
        {
            return;
        }

        await _emailService.SendWelcomeEmailAsync(member, cancellationToken);
    }
}
