using AutoMapper;
using Metaforas.Application.Helpers;
using Metaforas.Application.Interfaces;
using Metaforas.Application.Models;
using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Metaforas.Application.Services
{
    public class TimeApplicationService : ITimeApplicationService
    {
        private readonly ITimeService _timeSerivce;
        private readonly IMapper _mapper;
        private readonly Guid _idUsuario;

        public TimeApplicationService(ITimeService timeSerivce, IMapper mapper, IHttpContextAccessor context)
        {
            _timeSerivce = timeSerivce;
            _mapper = mapper;
            _idUsuario = HelperClaim.RetornaIdUsuarioToken(context);

        }

        public void Atualizar(TimePutModel model)
        {
            var time = _mapper.Map<Time>(model);

            time.DataAlteracao = DateTime.UtcNow;
            time.UsuarioAlteracao = _idUsuario;

            if (!model.Ativo)
            {
              time.DataInativacao = DateTime.UtcNow;
              time.UsuarioInativacao = _idUsuario;
            }

            _timeSerivce.Atualizar(time);
        }

        public void Criar(TimePostModel model)
        {
            var time = _mapper.Map<Time>(model);
            time.UsuarioCriacao = _idUsuario;
            time.DataCriacao = DateTime.UtcNow;
            time.Ativo = true;

            _timeSerivce.Criar(time);
        }

        public TimeGetModel? ExibirTimePorId(Guid id)
        {
            var time = _timeSerivce.ExibirTimePorId(id);
            var model = _mapper.Map<TimeGetModel>(time);
            return model;
        }

        public List<TimeGetModel>? ExibirTodosTimes()
        {
            var time = _timeSerivce.ExibirTodosTimes();
            var model = _mapper.Map<List<TimeGetModel>>(time);
            return model;
        }
    }
}
