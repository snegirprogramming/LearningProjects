using Gatherly.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gatherly.Persistence.Interceptors
{
    public sealed class UpdateAuditableEntitiesInterceptor
        : SaveChangesInterceptor
    {
        public override ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData,
            int result,
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            if (dbContext is null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<IAuditableEntity>> entries =
                dbContext
                    .ChangeTracker
                    .Entries<IAuditableEntity>();

            foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(a => a.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(a => a.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}