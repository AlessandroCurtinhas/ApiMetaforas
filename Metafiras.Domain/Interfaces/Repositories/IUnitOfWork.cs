
namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        public IFraseRepository FraseRepository { get; }
        public IPensadorRepository PensadorRepository { get; }
        public IPensadorTimeRepository PensadorTimeRepository  { get; }
        public ITimeRepository TimeRepository { get;}
    }
}
