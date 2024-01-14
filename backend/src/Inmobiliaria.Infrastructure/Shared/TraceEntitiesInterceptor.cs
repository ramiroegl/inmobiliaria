using Inmobiliaria.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Inmobiliaria.Infrastructure.Shared;

public class TraceEntitiesInterceptor(ITimeProvider timeProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry>? modifiedEntries = eventData.Context?.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .ToList();

        if (modifiedEntries is null || !modifiedEntries.Any())
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        foreach (EntityEntry entry in modifiedEntries)
        {
            if (entry.Entity is not Entity entity)
            {
                continue;
            }

            if (entry.State is EntityState.Added)
            {
                entity.CreatedOn = timeProvider.UtcNow;
            }

            entity.UpdatedOn = timeProvider.UtcNow;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
