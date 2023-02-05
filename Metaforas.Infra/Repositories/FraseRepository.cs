using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Metaforas.Infra.Repositories
{
    public class FraseRepository : BaseRepository, IFraseRepository
    {
        private readonly ServerContext _context;
        public FraseRepository(ServerContext serverContext) : base(serverContext)
        {
            _context = serverContext;
        }
        private IQueryable<Frase> EhAtivo(IQueryable<Frase> query, Boolean? ativo)
        {
            return query.Where(p => p.Ativo == ativo);
        }

        public Frase? ExibirFrasePorId(Guid idFrase, Boolean? ativo = null)
        {
            IQueryable<Frase> query = _context.Frases;
            query = query.AsNoTracking()
                         .Where(f => f.IdFrase == idFrase);
            if (ativo != null) query = EhAtivo(query, ativo);
            return query.FirstOrDefault();
        }

        public List<Frase>? ExibirFrasePorPensador(Guid IdPensador, Boolean? ativo = null)
        {
            IQueryable<Frase> query = _context.Frases;
            query = query.Where(f => f.IdPensador == IdPensador);
            if (ativo != null) query = EhAtivo(query, ativo);
            return query.AsNoTracking().ToList();
        }

        public List<Frase>? ExibirTodasFrases()
        {
            IQueryable<Frase> query = _context.Frases;
            return query.AsNoTracking().ToList();
           
        }

        public List<Frase>? ExibirTodasFrasesPorTime(Guid IdTime, Boolean? ativo = null)
        {
            IQueryable<Frase> query = _context.Frases;
            query = query.Where(f => f.IdTime == IdTime);
            if (ativo != null) query = EhAtivo(query, ativo);
            return query.AsNoTracking().ToList();
        }
    }
}