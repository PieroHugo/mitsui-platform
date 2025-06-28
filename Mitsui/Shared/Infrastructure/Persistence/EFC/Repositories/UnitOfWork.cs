using Mitsui.Shared.Domain.Repositories;
using Mitsui.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Mitsui.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}