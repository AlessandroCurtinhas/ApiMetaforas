using AutoMapper;
using Metaforas.Application.Helpers;
using Metaforas.Application.Interfaces;
using Metaforas.Application.Models;
using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Metaforas.Application.Services
{
    public class PensadorTimeApplicationService : IPensadorTimeApplicationService
    {
        private readonly IPensadorTimeService _pensadorTimeSerivce;
        private readonly IMapper _mapper;
        private readonly Guid _idUsuario;

        public PensadorTimeApplicationService(IPensadorTimeService pensadorTimeSerivce, IMapper mapper, IHttpContextAccessor context)
        {
            _pensadorTimeSerivce = pensadorTimeSerivce;
            _mapper = mapper;
            _idUsuario = HelperClaim.RetornaIdUsuarioToken(context);
        }

        public void Atualizar(PensadorTimePutModel model)
        {
            var pensadorTime = _mapper.Map<PensadorTime>(model);

            pensadorTime.DataAlteracao = DateTime.UtcNow;
            pensadorTime.UsuarioAlteracao = _idUsuario;

            if (!model.Ativo)
            {
                pensadorTime.DataInativacao = DateTime.UtcNow;
                pensadorTime.UsuarioInativacao = _idUsuario;
            }

            _pensadorTimeSerivce.Atualizar(pensadorTime);
        }

        public void Criar(PensadorTimePostModel model)
        {
            var pensadorTime = _mapper.Map<PensadorTime>(model);
            pensadorTime.UsuarioCriacao = _idUsuario;
            pensadorTime.DataCriacao = DateTime.UtcNow;
            pensadorTime.Ativo = true;

            _pensadorTimeSerivce.Criar(pensadorTime);
        }

        public List<PensadorTimeGetModel>? ExibirPensadorPorPensador(Guid idPensador)
        {
            var pensadorTime = _pensadorTimeSerivce.ExibirPensadorPorPensador(idPensador);
            var model = _mapper.Map<List<PensadorTimeGetModel>>(pensadorTime);
            return model;
        }

        public List<PensadorTimeGetModel>? ExibirPensadorTimePorTime(Guid idTime)
        {
            var pensadorTime = _pensadorTimeSerivce.ExibirPensadorTimePorTime(idTime);
            var model = _mapper.Map<List<PensadorTimeGetModel>>(pensadorTime);
            return model;
        }

        public PensadorTimeGetModel? ExibirPensandorTimePorId(Guid idPensadorTime)
        {
            var pensadorTime = _pensadorTimeSerivce.ExibirPensandorTimePorId(idPensadorTime);
            var model = _mapper.Map<PensadorTimeGetModel>(pensadorTime);
            return model;
        }

        public List<PensadorTimeGetModel>? ExibirTodosPensadoresTime()
        {
            var pensadorTime = _pensadorTimeSerivce.ExibirTodosPensadoresTime();
            var model = _mapper.Map<List<PensadorTimeGetModel>>(pensadorTime);
            return model;
        }
    }
}
