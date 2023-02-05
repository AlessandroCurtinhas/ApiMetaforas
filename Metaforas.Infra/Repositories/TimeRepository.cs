using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Repositories
{
    public class TimeRepository : BaseRepository, ITimeRepository
    {
        private readonly ServerContext _serverContext;
        public TimeRepository(ServerContext serverContext) : base(serverContext)
        {
            _serverContext = serverContext;
        }

        private IQueryable<Time> EhAtivo(IQueryable<Time> query, Boolean? ativo)
        {
            return query.Where(p => p.Ativo == ativo);
        }


        public Time? ExbibirTimePorId(Guid id, Boolean? ativo = null)
        {
            IQueryable<Time> query = _serverContext.Times;
            query = query.AsNoTracking()
                            .Include(p => p.Frases)
                            .ThenInclude(p => p.Pensador)
                         .Where(t => t.IdTime == id);
            if (ativo != null) query = EhAtivo(query, ativo);
            return query.FirstOrDefault();

        }

        public List<Time>? ExibirTodosTimes()
        {
            IQueryable<Time> query = _serverContext.Times;
            return query.AsNoTracking().ToList();
                        
        }
    }
}