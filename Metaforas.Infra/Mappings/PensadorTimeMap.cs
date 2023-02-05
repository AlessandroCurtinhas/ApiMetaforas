using Metaforas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metaforas.Infra.Mappings
{
    public class PensadorTimeMap : IEntityTypeConfiguration<PensadorTime>
    {
        public void Configure(EntityTypeBuilder<PensadorTime> builder)
        {
            builder.HasKey(p => p.IdPensadorTime);
            
            builder.HasOne(p => p.Pensador)
                   .WithMany(pe => pe.PensadorTimes)
                   .HasForeignKey(p => p.IdPensador);

            builder.HasOne(p => p.Time)
                   .WithMany(te => te.PensadorTimes)
                   .HasForeignKey(p => p.IdTime);
        }
    }
}
