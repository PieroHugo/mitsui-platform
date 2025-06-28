using Mitsui.Sale.Domain.Model.Entities;
using Mitsui.Sale.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mitsui.Sale.Infrastructure.Persistence.EFC.Configurations;

/// <summary>
/// Entity Framework configuration for <see cref="Bill"/>.
/// </summary>
public class BillEntityTypeConfiguration : IEntityTypeConfiguration<Bill>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("bills", "mitsui");
        builder.HasKey(b => b.BillNumber);
        builder.Property(b => b.BillNumber).ValueGeneratedOnAdd();

        builder.Property(b => b.Customer).IsRequired().HasMaxLength(100);
        builder.Property(b => b.ServiceId).IsRequired();
        builder.Property(b => b.Plate).HasMaxLength(10);
        builder.Property(b => b.Emission).IsRequired();
        builder.Property(b => b.Amount).IsRequired();

        builder.OwnsOne(b => b.Invoice, inv =>
        {
            inv.Property(i => i.SerialNumber).HasMaxLength(10).HasColumnName("serial_number");
            inv.Property(i => i.SequentialNumber).HasMaxLength(10).HasColumnName("sequential_number");
            inv.HasIndex(i => new { i.SerialNumber, i.SequentialNumber }).IsUnique();
        });
    }
}
