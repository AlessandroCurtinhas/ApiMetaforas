using Metaforas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metaforas.Infra.Mappings
{
    public class FraseMap : IEntityTypeConfiguration<Frase>
    {
        public void Configure(EntityTypeBuilder<Frase> builder)
        {
            builder.HasKey(p => p.IdFrase);

            builder.Property(p => p.FraseTexto)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(500);
            
            builder.HasOne(p => p.Pensador)
                   .WithMany(f => f.Frases)
                   .HasForeignKey(p => p.IdPensador);

            builder.HasOne(p => p.Time)
                   .WithMany(t => t.Frases)
                   .HasForeignKey(p => p.IdTime);

           
        }
    }
}
