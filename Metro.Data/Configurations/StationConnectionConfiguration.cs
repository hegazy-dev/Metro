using Metro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StationConnectionConfiguration : IEntityTypeConfiguration<StationConnection>
{
    public void Configure(EntityTypeBuilder<StationConnection> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id)
               .ValueGeneratedNever();

        builder.HasIndex(sc => sc.FromStationId);
        builder.HasIndex(sc => sc.ToStationId);

        builder.HasOne(sc => sc.FromStation)
               .WithMany(s => s.FromConnections)
               .HasForeignKey(sc => sc.FromStationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sc => sc.ToStation)
               .WithMany(s => s.ToConnections)
               .HasForeignKey(sc => sc.ToStationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}