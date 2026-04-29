using Metro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .ValueGeneratedNever();

        builder.HasIndex(s => new { s.LineId, s.Order });

        builder.HasOne(s => s.Line)
               .WithMany(l => l.Stations)
               .HasForeignKey(s => s.LineId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}