using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Metro.Core.Entities;

namespace Metro.Data.Configurations;

public class LineConfiguration : IEntityTypeConfiguration<Line>
{
    public void Configure(EntityTypeBuilder<Line> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
               .ValueGeneratedNever();

        builder.Property(l => l.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.Color)
               .IsRequired()
               .HasMaxLength(50);
    }
}