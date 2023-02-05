using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Domain.Interfaces.Services;
using System.Linq;

namespace Metaforas.Domain.Services
{

    public class TimeService : ITimeService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(Time entity)
        {
            var time = _unitOfWork.TimeRepository.ExbibirTimePorId(entity.IdTime);
            if (time == null) throw new ArgumentException("Não foi possível encontrar o time informado.");

            time.DataAlteracao = entity.DataAlteracao;
            time.UsuarioAlteracao = entity.UsuarioAlteracao;
            time.Nome = entity.Nome;
            time.Ativo = entity.Ativo;

            if (!entity.Ativo)
            {
                time.UsuarioInativacao = entity.UsuarioInativacao;
                time.DataInativacao = entity.DataInativacao;
            }

            _unitOfWork.TimeRepository.Atualizar(time);
        }

        public void Criar(Time entity)
        {
            var time = _unitOfWork.TimeRepository.ExbibirTimePorId(entity.IdTime);
            if (time != null) throw new ArgumentException("O id informado já existe");

            _unitOfWork.TimeRepository.Criar(entity);
        }

        public Time? ExibirTimePorId(Guid id)
        {
            var time = _unitOfWork.TimeRepository.ExbibirTimePorId(id);
            if(time == null) throw new ArgumentException("Não foi possível encontrar o time informado.");

            return time;
        }

        public List<Time>? ExibirTodosTimes()
        {
            return _unitOfWork.TimeRepository.ExibirTodosTimes();
        }
    }
}
