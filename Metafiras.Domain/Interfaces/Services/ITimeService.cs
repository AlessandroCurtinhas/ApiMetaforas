using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Services
{
    public interface ITimeService : IBaseService<Time>
    {
        public Time? ExibirTimePorId(Guid id);
        public List<Time>? ExibirTodosTimes();
    }
}
