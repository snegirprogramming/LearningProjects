using Gatherly.Domain.Primitives;
using Gatherly.Persistence.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace Gatherly.Persistence.Interceptors;

public sealed class ConvertDomainEventsToOutboxMessagesInterceptor
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

        var outboxMessages = dbContext.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.GetDomainEvents();
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                OccuredOnUtc = DateTime.UtcNow,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(
                    domainEvent,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                    })
            })
            .ToList();

        dbContext.Set<OutboxMessage>().AddRange(outboxMessages);

        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}