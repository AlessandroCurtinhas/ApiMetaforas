using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface IFraseRepository : IBaseRepository
    {
        List<Frase>? ExibirFrasePorPensador(Guid IdPensador, Boolean? ativo = null);
        List<Frase>? ExibirTodasFrases();
        List<Frase>? ExibirTodasFrasesPorTime(Guid IdTime, Boolean? ativo = null);
        Frase? ExibirFrasePorId(Guid idFrase, Boolean? ativo = null);
    }
}
