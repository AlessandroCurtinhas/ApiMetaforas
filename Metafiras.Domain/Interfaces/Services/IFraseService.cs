using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Services
{
    public interface IFraseService : IBaseService<Frase>
    {
        Frase? ExibirFrasePorId(Guid idFrase);
        List<Frase>? ExibirFrasePorPensador(Guid IdPensador);
        List<Frase>? ExibirTodasFrases();
        List<Frase>? ExibirTodasFrasesPorTime(Guid IdTime);
    }
}
