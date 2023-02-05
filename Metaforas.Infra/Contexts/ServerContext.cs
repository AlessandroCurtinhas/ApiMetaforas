using Metaforas.Domain.Entities;
using Metaforas.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Contexts
{
    public class ServerContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("User ID=AplicacaoAPI;Password=Admin@123456;Host=localhost;Port=7777;Database=MetaforasAPI;Pooling=true;");
        //}

        public ServerContext( DbContextOptions<ServerContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FraseMap());
            modelBuilder.ApplyConfiguration(new PensadorMap());
            modelBuilder.ApplyConfiguration(new PensadorTimeMap());
            modelBuilder.ApplyConfiguration(new TimeMap());
        }

        public DbSet<Frase> Frases { get; set; }
        public DbSet<Pensador> Pensadores { get; set; }
        public DbSet<PensadorTime> PensadorTimes { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
