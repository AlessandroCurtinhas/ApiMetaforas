using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Services
{
    public interface IPensadorService : IBaseService<Pensador>
    {  
        Pensador? ExibirPensadorPorUsuario(Guid idUsuario);
        List<Pensador>? ExibirTodosPensadores();
        Pensador? ExbibirPensadorPorId(Guid id);

    }
}
