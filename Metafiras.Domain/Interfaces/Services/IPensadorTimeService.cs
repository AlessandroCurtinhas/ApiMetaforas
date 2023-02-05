using Metaforas.Domain.Entities;

namespace Metaforas.Domain.Interfaces.Services
{
    public interface IPensadorTimeService : IBaseService<PensadorTime>
    {
        public List<PensadorTime>? ExibirPensadorPorPensador(Guid IdPensador);
        public List<PensadorTime>? ExibirPensadorTimePorTime(Guid IdTime);
        public PensadorTime? ExibirPensandorTimePorId(Guid IdPensadorTime);
        public List<PensadorTime>? ExibirTodosPensadoresTime();
    }
}
