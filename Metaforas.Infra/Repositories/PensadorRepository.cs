using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Repositories
{
    public class PensadorRepository : BaseRepository, IPensadorRepository
    {

        private readonly ServerContext _severContext;

        public PensadorRepository(ServerContext severContext) : base(severContext)
        {
            _severContext = severContext;
        }
        private IQueryable<Pensador> EhAtivo(IQueryable<Pensador> query, Boolean? ativo)
        {
            return query.Where(p => p.Ativo == ativo);
        }
        public Pensador? ExbibirPensadorPorId(Guid id, Boolean? ativo = null)
        {
            IQueryable<Pensador> query = _severContext.Pensadores;

            query = query.AsNoTracking()
                    .Where(p => p.IdPensador.Equals(id));

            if (ativo != null) query = EhAtivo(query, ativo);

            return query.FirstOrDefault();
        }

        public Pensador? ExibirPensadorPorUsuario(Guid idUsuario, Boolean? ativo = null)
        {
            IQueryable<Pensador> query = _severContext.Pensadores;

            return query.FirstOrDefault(p => p.IdUsuario.Equals(idUsuario));

        }

        public List<Pensador>? ExibirTodosPensadores()
        {
            IQueryable<Pensador> query = _severContext.Pensadores;

            return query.AsNoTracking().ToList();
        }
    }
}