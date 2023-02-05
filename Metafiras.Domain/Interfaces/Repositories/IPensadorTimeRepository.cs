using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface IPensadorTimeRepository : IBaseRepository
    {
        PensadorTime? ExibirPensandorTimePorId(Guid idPensadorTime, Boolean? ativo = null);
        List<PensadorTime>? ExibirTodosPensadoresTime();
        List<PensadorTime>? ExibirPensadorPorPensador(Guid idPensador, Boolean? ativo = null);
        List<PensadorTime>? ExibirPensadorTimePorTime(Guid idTime, Boolean? ativo = null);
        List<PensadorTime>? ExibirPensadorTimePorTimeePensador(Guid idTime, Guid idPensador, Boolean? ativo = null);

    }
}
