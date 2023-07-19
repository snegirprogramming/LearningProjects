using Gatherly.Domain.Entities;

namespace Gatherly.Domain.Repositories;

public interface IInvitationRepository
{
    void Add(Invitation invitation);
    Task<Invitation> GetByIdAsync(Guid invitationId, CancellationToken cancellationToken);
}
