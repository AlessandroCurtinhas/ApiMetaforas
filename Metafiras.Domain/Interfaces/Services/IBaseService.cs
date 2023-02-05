
namespace Metaforas.Domain.Interfaces.Services
{
    public interface IBaseService<T>
    {
        void Criar(T entity);
        void Atualizar(T entity);

    }
}
