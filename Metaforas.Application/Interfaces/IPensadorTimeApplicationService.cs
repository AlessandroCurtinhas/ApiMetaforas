using Metaforas.Application.Models;

namespace Metaforas.Application.Interfaces
{
    public interface IPensadorTimeApplicationService : IBaseApplicationService<PensadorTimePostModel,PensadorTimePutModel>
    {
        public List<PensadorTimeGetModel>? ExibirPensadorPorPensador(Guid IdPensador);
        public List<PensadorTimeGetModel>? ExibirPensadorTimePorTime(Guid IdTime);
        public PensadorTimeGetModel? ExibirPensandorTimePorId(Guid IdPensadorTime);
        public List<PensadorTimeGetModel>? ExibirTodosPensadoresTime();
    }
}
