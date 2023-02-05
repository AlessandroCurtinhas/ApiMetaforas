using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Domain.Interfaces.Services;

namespace Metaforas.Domain.Services
{
    public class PensadorService : IPensadorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PensadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(Pensador entity)
        {
            var pensador = _unitOfWork.PensadorRepository.ExbibirPensadorPorId(entity.IdPensador);
            if (pensador == null) throw new ArgumentException("Não foi possível encontrar o pensador informado.");

            pensador.DataAlteracao = entity.DataAlteracao;
            pensador.UsuarioAlteracao = entity.UsuarioAlteracao;
            pensador.Nome = entity.Nome;
            pensador.Ativo = entity.Ativo;

            if (!entity.Ativo)
            {
                pensador.UsuarioInativacao = entity.UsuarioInativacao;
                pensador.DataInativacao = entity.DataInativacao;
            }
            
            _unitOfWork.PensadorRepository.Atualizar(pensador);
        }

        public void Criar(Pensador entity)
        {
            var pensador = _unitOfWork.PensadorRepository.ExibirPensadorPorUsuario(entity.IdUsuario);
            if (pensador != null) throw new ArgumentException("O usuário informado já está associado a um pensador");

            _unitOfWork.PensadorRepository.Criar(entity);
        }

        public Pensador? ExbibirPensadorPorId(Guid id)
        {
            var pensador = _unitOfWork.PensadorRepository.ExbibirPensadorPorId(id);
            if (pensador == null) throw new ArgumentException("Não foi possível encontrar um pensador com o Id informado");

            return pensador;
        }

        public Pensador? ExibirPensadorPorUsuario(Guid idUsuario)
        {
            var pensador =  _unitOfWork.PensadorRepository.ExibirPensadorPorUsuario(idUsuario);
            if (pensador == null) throw new ArgumentException("Não foi possível encontrar um pensador associado ao usuario");

            return pensador;
        }

        public List<Pensador>? ExibirTodosPensadores()
        {
            var pensadores = _unitOfWork.PensadorRepository.ExibirTodosPensadores();
            return pensadores;
        }
    }
}
