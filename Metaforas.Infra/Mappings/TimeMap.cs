using Metaforas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metaforas.Infra.Mappings
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(p => p.IdTime);

            builder.Property(p => p.Nome)
                   .HasMaxLength(100);
            
            builder.HasIndex(p => p.Nome)
                   .IsUnique();            
        }
    }
}
