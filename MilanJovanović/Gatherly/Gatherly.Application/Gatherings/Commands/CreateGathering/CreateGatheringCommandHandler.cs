using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using MediatR;

namespace Gatherly.Application.Gatherings.Commands.CreateGathering;

internal sealed class CreateGatheringCommandHandler : IRequestHandler<CreateGatheringCommand>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IGatheringRepository _getheringRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGatheringCommandHandler(
        IMemberRepository memberRepository,
        IGatheringRepository getheringRepository,
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _getheringRepository = getheringRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateGatheringCommand request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);

        if (member is null)
        {
            return Unit.Value;
        }

        var gathering = Gathering.Create(
            Guid.NewGuid(),
            member,
            request.Type,
            request.ScheduledAtUtc,
            request.Name,
            request.Location,
            request.MaximumNumberOfAttendees,
            request.InvitationsValidBeforeInHours);

        _getheringRepository.Add(gathering);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
