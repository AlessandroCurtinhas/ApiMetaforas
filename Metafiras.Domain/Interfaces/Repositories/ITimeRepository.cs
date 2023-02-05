using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface ITimeRepository : IBaseRepository
    {
        List<Time>? ExibirTodosTimes();
        public Time? ExbibirTimePorId(Guid id, Boolean? ativo = null);
    }
}
