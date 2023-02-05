using Metaforas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metaforas.Infra.Mappings
{
    public class PensadorMap : IEntityTypeConfiguration<Pensador>
    {
        public void Configure(EntityTypeBuilder<Pensador> builder)
        {
            builder.HasKey(p => p.IdPensador);

            builder.HasIndex(p => p.IdUsuario)
                   .IsUnique();

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
