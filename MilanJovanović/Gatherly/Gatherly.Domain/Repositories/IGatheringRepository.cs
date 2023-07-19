using Gatherly.Domain.Entities;

namespace Gatherly.Domain.Repositories;

public interface IGatheringRepository
{
    void Add(Gathering gathering);
    Task<Gathering> GetByIdAsync(Guid gatheringId, CancellationToken cancellationToken);
    Task<Gathering> GetByIdWithCreatorAsync(Guid gatheringId, CancellationToken cancellationToken);
}
