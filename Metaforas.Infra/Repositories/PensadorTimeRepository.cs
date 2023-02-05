using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Repositories
{
    public class PensadorTimeRepository : BaseRepository, IPensadorTimeRepository
    {
        private readonly ServerContext _serverContext;
        public PensadorTimeRepository(ServerContext serverContext) : base(serverContext)
        {
            _serverContext = serverContext;
        }

        private IQueryable<PensadorTime> EhAtivo(IQueryable<PensadorTime> query, Boolean? ativo)
        {
           return query.Where(p => p.Ativo == ativo);
        }

        public List<PensadorTime>? ExibirPensadorPorPensador(Guid idPensador, Boolean? ativo = null)
        {
            IQueryable<PensadorTime> query = _serverContext.PensadorTimes;

            query = query.AsNoTracking()
                         .Where(p => p.IdPensador == idPensador);

            if (ativo != null) query = EhAtivo(query, ativo);

            return query.ToList();
        }

        public List<PensadorTime>? ExibirPensadorTimePorTime(Guid idTime, Boolean? ativo = null)
        {
            IQueryable<PensadorTime> query = _serverContext.PensadorTimes;

            query = query.AsNoTracking()
                         .Where(p => p.IdTime == idTime);

            if (ativo != null) query = EhAtivo(query, ativo);

            return query.ToList();
        }

        public List<PensadorTime>? ExibirPensadorTimePorTimeePensador(Guid idTime, Guid idPensador, Boolean? ativo = null)
        {
            IQueryable<PensadorTime> query = _serverContext.PensadorTimes;

            query = query.AsNoTracking()
                         .Where(p => p.IdTime == idTime && p.IdPensador == idPensador );

            if (ativo != null) query = EhAtivo(query, ativo);

            return query.ToList();
        }

        public PensadorTime? ExibirPensandorTimePorId(Guid idPensadorTime, Boolean? ativo = null)
        {
            IQueryable<PensadorTime> query = _serverContext.PensadorTimes;

            query = query.AsNoTracking()
                         .Where(p => p.IdPensadorTime == idPensadorTime);

            if (ativo != null) query = EhAtivo(query, ativo);

            return query.FirstOrDefault();
        }
        public List<PensadorTime>? ExibirTodosPensadoresTime()
        {
            IQueryable<PensadorTime> query = _serverContext.PensadorTimes;
            return query.AsNoTracking().ToList();
        }
    }
}