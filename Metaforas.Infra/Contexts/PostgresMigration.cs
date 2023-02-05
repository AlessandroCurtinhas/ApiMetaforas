using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Metaforas.Infra.Contexts
{
    public class PostgresMigration : IDesignTimeDbContextFactory<ServerContext>
    {
        public ServerContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "AppSettings.json");
            configurationBuilder.AddJsonFile(path, false);

            //capturar a connectionstring mapeada dentro do arquivo
            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("ApiMetaforas").Value;

            //instanciar a classe SqlServerContext
            var builder = new DbContextOptionsBuilder<ServerContext>();

            builder.UseNpgsql(connectionString);

            return new ServerContext(builder.Options);
        }
    }
}
