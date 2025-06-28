using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Sale.Infrastructure.Persistence.EFC.Configurations;

/// <summary>
/// Model builder extensions for the Sale bounded context.
/// </summary>
public static class SaleModelBuilderExtensions
{
    /// <summary>
    /// Applies Sale context configuration.
    /// </summary>
    public static void ApplySaleConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SaleModelBuilderExtensions).Assembly);
    }
}
