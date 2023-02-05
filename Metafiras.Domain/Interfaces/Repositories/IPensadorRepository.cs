using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface  IPensadorRepository : IBaseRepository
    {
        Pensador? ExibirPensadorPorUsuario(Guid idUsuario, Boolean? ativo = null);
        List<Pensador>? ExibirTodosPensadores();
        Pensador? ExbibirPensadorPorId(Guid id, Boolean? ativo = null);

    }
}
