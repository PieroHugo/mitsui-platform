using CrewWeb.VehixPlatform.API.Sale.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Sale.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Sale.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Sale.Infrastructure.Persistence.EFC.Repositories;

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
