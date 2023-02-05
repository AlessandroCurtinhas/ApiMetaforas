using Metaforas.Application.Models;

namespace Metaforas.Application.Interfaces
{
    public interface IFraseApplicationService : IBaseApplicationService<FrasePostModel, FrasePutModel>
    {
        FraseGetModel? ExibirFrasePorId(Guid idFrase);
        List<FraseGetModel>? ExibirFrasePorPensador(Guid IdPensador);
        List<FraseGetModel>? ExibirTodasFrases();
        List<FraseGetModel>? ExibirTodasFrasesPorTime(Guid IdTime);
    }
}
