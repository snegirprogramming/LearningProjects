using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using Gatherly.Domain.ValueObjects;
using MediatR;

namespace Gatherly.Application.Members.Commands.CreateMemeber;

internal sealed class CreateMemeberCommnadHandler : IRequestHandler<CreateMemeberCommnad, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemeberCommnadHandler(
        IMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateMemeberCommnad request, CancellationToken cancellationToken)
    {
        var firstNameResult = FirstName.Create(request.FirstName);

        if (firstNameResult.IsFailure)
        {
            // Log error
            return Unit.Value;
        }

        var member = new Member(
            Guid.NewGuid(),
            firstNameResult.Value,
            request.LastName,
            request.Email);

        _memberRepository.Add(member);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}