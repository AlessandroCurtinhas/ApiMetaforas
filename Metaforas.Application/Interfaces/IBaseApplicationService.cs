namespace Metaforas.Application.Interfaces
{
    public interface IBaseApplicationService<C, A>
    {
        void Criar(C model);
        void Atualizar(A model);
    }
}
