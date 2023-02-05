using AutoMapper;
using Metaforas.Application.Helpers;
using Metaforas.Application.Interfaces;
using Metaforas.Application.Models;
using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Metaforas.Application.Services
{
    public class PensadorApplicationService : IPensadorApplicationService
    {
        private readonly IPensadorService _pensadorService;
        private readonly IMapper _mapper;
        private readonly Guid _idUsuario;
        public PensadorApplicationService(IPensadorService pensadorService, IMapper mapper, IHttpContextAccessor context)
        {
            _pensadorService = pensadorService;
            _mapper = mapper;
            _idUsuario = HelperClaim.RetornaIdUsuarioToken(context);
        }

        public void Atualizar(PensadorPutModel model)
        {
            var pensador = _mapper.Map<Pensador>(model);

            pensador.DataAlteracao = DateTime.UtcNow;
            pensador.UsuarioAlteracao = _idUsuario;

            if (!model.Ativo)
            {
                pensador.UsuarioInativacao = _idUsuario;
                pensador.DataInativacao = DateTime.UtcNow;
            }
            _pensadorService.Atualizar(pensador);
        }

        public void Criar(PensadorPostModel model)
        {
            
            var pensador = _mapper.Map<Pensador>(model);
            pensador.IdPensador = Guid.NewGuid();
            pensador.UsuarioCriacao = _idUsuario;
            pensador.DataCriacao = DateTime.UtcNow;
            pensador.Ativo = true;
            
            _pensadorService.Criar(pensador);
 
        }

        public PensadorGetModel? ExbibirPensadorPorId(Guid id)
        {
            var pensadorEntity =  _pensadorService.ExbibirPensadorPorId(id);
            var model = _mapper.Map<PensadorGetModel>(pensadorEntity);
            return model;
        }

        public PensadorGetModel? ExibirPensadorPorUsuario(Guid idUsuario)
        {
            var pensadorEntity = _pensadorService.ExibirPensadorPorUsuario(idUsuario);
            var model = _mapper.Map<PensadorGetModel>(pensadorEntity);
            return model;
        }

        public List<PensadorGetModel>? ExibirTodosPensadores()
        {
            var pensadores = _pensadorService.ExibirTodosPensadores();
            var pensadorGetModelList = _mapper.Map<List<PensadorGetModel>>(pensadores);
            return pensadorGetModelList;
        }
    }
}
