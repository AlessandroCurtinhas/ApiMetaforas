using Metaforas.Application.Models;

namespace Metaforas.Application.Interfaces
{
    public interface ITimeApplicationService : IBaseApplicationService<TimePostModel, TimePutModel>
    {
        public TimeGetModel? ExibirTimePorId(Guid id);
        public List<TimeGetModel>? ExibirTodosTimes();
    }
}
