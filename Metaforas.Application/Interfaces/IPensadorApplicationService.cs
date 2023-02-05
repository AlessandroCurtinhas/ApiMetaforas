using Metaforas.Application.Models;

namespace Metaforas.Application.Interfaces
{
    public interface IPensadorApplicationService : IBaseApplicationService<PensadorPostModel, PensadorPutModel>
    {

        PensadorGetModel? ExibirPensadorPorUsuario(Guid idUsuario);
        List<PensadorGetModel>? ExibirTodosPensadores();
        PensadorGetModel? ExbibirPensadorPorId(Guid id);
    }
}
