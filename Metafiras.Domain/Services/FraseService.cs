using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Domain.Interfaces.Services;

namespace Metaforas.Domain.Services
{
    public class FraseService : IFraseService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FraseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(Frase entity)
        {
            var frase = _unitOfWork.FraseRepository.ExibirFrasePorId(entity.IdFrase);
            if (frase == null) throw new ArgumentException("Não foi possível encontrar a frase com o id Informado");


            frase.DataAlteracao = entity.DataAlteracao;
            frase.UsuarioAlteracao = entity.UsuarioAlteracao;
            frase.FraseTexto = entity.FraseTexto;
            frase.Ativo = entity.Ativo;

            if (!entity.Ativo)
            {
                frase.UsuarioInativacao = entity.UsuarioInativacao;
                frase.DataInativacao = entity.DataInativacao;
            }

            _unitOfWork.FraseRepository.Atualizar(frase);
        }

        public void Criar(Frase entity)
        {
            if (!ValidaTimePensadores(entity.IdPensador,entity.IdTime)) throw new ArgumentException("O time ou Pensador informado não foi encontrado ou está desativado.");
            _unitOfWork.PensadorRepository.Criar(entity);
        }

        public Frase? ExibirFrasePorId(Guid idFrase)
        {
            var frase = _unitOfWork.FraseRepository.ExibirFrasePorId(idFrase);
            if (frase == null) throw new ArgumentException("Não foi possível encontrar uma frase com o Id informado");

            return frase;
        }

        public List<Frase>? ExibirFrasePorPensador(Guid IdPensador)
        {
            var frase = _unitOfWork.FraseRepository.ExibirFrasePorPensador(IdPensador);
            if (frase.Count == 0) throw new ArgumentException("Não foi possível encontrar frases para o pensador informado");

            return frase;
        }

        public List<Frase>? ExibirTodasFrases()
        {
            return  _unitOfWork.FraseRepository.ExibirTodasFrases();
        }

        public List<Frase>? ExibirTodasFrasesPorTime(Guid IdTime)
        {
            var frase = _unitOfWork.FraseRepository.ExibirTodasFrasesPorTime(IdTime);
            if (frase.Count == 0) throw new ArgumentException("Não foi possível encontrar frases para o time informado");

            return frase;
        }

        private bool ValidaTimePensadores(Guid idPensador, Guid IdTime)
        {
            var time = _unitOfWork.TimeRepository.ExbibirTimePorId(IdTime, true);
            var pensador = _unitOfWork.PensadorRepository.ExbibirPensadorPorId(idPensador, true);

            return time == null || pensador == null ? false : true;

        }
    }
}
