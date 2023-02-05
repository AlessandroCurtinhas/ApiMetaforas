using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Domain.Interfaces.Services;

namespace Metaforas.Domain.Services
{
    public class PensadorTimeService : IPensadorTimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PensadorTimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(PensadorTime entity)
        {
            var pensadorTime = _unitOfWork.PensadorTimeRepository.ExibirPensandorTimePorId(entity.IdPensadorTime);
            if (pensadorTime == null) throw new ArgumentException("Não foi possível encontrar o pensadorTime com o Id informado.");

            pensadorTime.DataAlteracao = entity.DataAlteracao;
            pensadorTime.UsuarioAlteracao = entity.UsuarioAlteracao;
            pensadorTime.Ativo = entity.Ativo;

            if (!entity.Ativo)
            {
                pensadorTime.UsuarioInativacao = entity.UsuarioInativacao;
                pensadorTime.DataInativacao = entity.DataInativacao;
            }
            _unitOfWork.PensadorRepository.Atualizar(pensadorTime);
        }

        public void Criar(PensadorTime entity)
        {
            var pensadorTime = _unitOfWork.PensadorTimeRepository.ExibirPensadorTimePorTimeePensador(entity.IdTime,entity.IdPensador);
            if (pensadorTime.Count >= 1) throw new ArgumentException("O time informado já está associado ao pensador.");
            if(!ValidaTimePensadores(entity.IdPensador, entity.IdTime)) throw new ArgumentException("O time ou Pensador informado não foi encontrado ou está desativado.");

            _unitOfWork.PensadorRepository.Criar(entity);
        }

        public List<PensadorTime>? ExibirPensadorPorPensador(Guid IdPensador)
        {
            var pensadorTime = _unitOfWork.PensadorTimeRepository.ExibirPensadorPorPensador(IdPensador);
            if (pensadorTime.Count == 0) throw new ArgumentException("Não foi possível encontrar times associados ao pensador");

            return pensadorTime;
        }

        public List<PensadorTime>? ExibirPensadorTimePorTime(Guid IdTime)
        {
            var pensadorTime = _unitOfWork.PensadorTimeRepository.ExibirPensadorTimePorTime(IdTime);
            if (pensadorTime.Count == 0) throw new ArgumentException("Não foi possível encontrar pensadores associados ao times");

            return pensadorTime;
        }

        public PensadorTime? ExibirPensandorTimePorId(Guid IdPensadorTime)
        {
            var pensadorTime = _unitOfWork.PensadorTimeRepository.ExibirPensandorTimePorId(IdPensadorTime);
            if (pensadorTime == null) throw new ArgumentException("Não foi possível encontrar associações de times e pensadores com o id informado");

            return pensadorTime;
        }

        public List<PensadorTime>? ExibirTodosPensadoresTime()
        {
            return _unitOfWork.PensadorTimeRepository.ExibirTodosPensadoresTime();
        }

        private bool ValidaTimePensadores(Guid idPensador, Guid IdTime)
        {
            var time = _unitOfWork.TimeRepository.ExbibirTimePorId(IdTime, true);
            var pensador = _unitOfWork.PensadorRepository.ExbibirPensadorPorId(idPensador, true);

            return time == null || pensador == null ? false : true;

        }
    }
}
