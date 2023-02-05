
namespace Metaforas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        void Criar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;

    }
}
