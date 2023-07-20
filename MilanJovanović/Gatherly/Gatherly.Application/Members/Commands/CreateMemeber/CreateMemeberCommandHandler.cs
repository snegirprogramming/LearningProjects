using Gatherly.Application.Abstractions.Messaging;
using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using Gatherly.Domain.Shared;
using Gatherly.Domain.ValueObjects;

namespace Gatherly.Application.Members.Commands.CreateMemeber;

internal sealed class CreateMemeberCommandHandler : ICommandHandler<CreateMemeberCommand>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemeberCommandHandler(
        IMemberRepository memberRepository,
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateMemeberCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);
        var firstNameResult = FirstName.Create(request.FirstName);
        var lastNameResult = LastName.Create(request.LastName);

        var isEmailUniqueAsync = await _memberRepository
            .IsEmailUniqueAsync(emailResult.Value, cancellationToken);

        var member = Member.Create(
            Guid.NewGuid(),
            emailResult.Value,
            firstNameResult.Value,
            lastNameResult.Value,
            isEmailUniqueAsync);

        _memberRepository.Add(member);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}