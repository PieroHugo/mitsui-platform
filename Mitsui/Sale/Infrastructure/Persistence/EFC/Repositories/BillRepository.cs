using Mitsui.Sale.Domain.Model.Entities;
using Mitsui.Sale.Domain.Model.ValueObjects;
using Mitsui.Sale.Domain.Repositories;
using Mitsui.Shared.Infrastructure.Persistence.EFC.Configuration;
using Mitsui.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mitsui.Sale.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework repository for bills.
/// </summary>
public class BillRepository : BaseRepository<Bill>, IBillRepository
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public BillRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<Bill?> FindByInvoiceAsync(Invoice invoice)
    {
        return await Context.Set<Bill>()
            .FirstOrDefaultAsync(b => b.Invoice.SerialNumber == invoice.SerialNumber && b.Invoice.SequentialNumber == invoice.SequentialNumber);
    }
}
