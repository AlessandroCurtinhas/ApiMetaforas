using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Repositories
{
    public abstract class  BaseRepository : IBaseRepository
    {

        private readonly ServerContext _serverContext;

        public BaseRepository(ServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _serverContext.Entry(entity).State = EntityState.Modified;
            _serverContext.SaveChanges();
        }

        public void Criar<T>(T entity) where T : class
        {
            _serverContext.Entry(entity).State = EntityState.Added;
            _serverContext.SaveChanges();
        }

    }
}