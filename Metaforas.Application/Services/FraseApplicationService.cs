using AutoMapper;
using Metaforas.Application.Helpers;
using Metaforas.Application.Interfaces;
using Metaforas.Application.Models;
using Metaforas.Domain.Entities;
using Metaforas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Metaforas.Application.Services
{
    public class FraseApplicationService : IFraseApplicationService
    {
        private readonly IFraseService _FraseDomainService;
        private readonly IMapper _mapper;
        private readonly Guid _idUsuario;
        public FraseApplicationService(IFraseService fraseDomainService, IMapper mapper, IHttpContextAccessor context)
        {
            _FraseDomainService = fraseDomainService;
            _mapper = mapper;
            _idUsuario = HelperClaim.RetornaIdUsuarioToken(context);
        }

        public void Atualizar(FrasePutModel model)
        {
            var frase = _mapper.Map<Frase>(model);

            frase.DataAlteracao = DateTime.UtcNow;
            frase.UsuarioAlteracao = _idUsuario;
            

            if (!model.Ativo)
            {
                frase.DataInativacao = DateTime.UtcNow;
                frase.UsuarioInativacao = _idUsuario;
            }

            _FraseDomainService.Atualizar(frase);
        }

        public void Criar(FrasePostModel model)
        {
            var frase = _mapper.Map<Frase>(model);
            frase.UsuarioCriacao = Guid.NewGuid();
            frase.DataCriacao = DateTime.UtcNow;
            frase.Ativo = true;

            _FraseDomainService.Criar(frase);
        }

        public FraseGetModel? ExibirFrasePorId(Guid idFrase)
        {
            var frase = _FraseDomainService.ExibirFrasePorId(idFrase);
            var model = _mapper.Map<FraseGetModel>(frase);
            return model;
        }

        public List<FraseGetModel>? ExibirFrasePorPensador(Guid IdPensador)
        {
            var frase = _FraseDomainService.ExibirFrasePorPensador(IdPensador);
            var model = _mapper.Map<List<FraseGetModel>>(frase);
            return model;
        }

        public List<FraseGetModel>? ExibirTodasFrases()
        {
            var frase = _FraseDomainService.ExibirTodasFrases();
            var model = _mapper.Map<List<FraseGetModel>>(frase);
            return model;
        }

        public List<FraseGetModel>? ExibirTodasFrasesPorTime(Guid IdTime)
        {
            var frase = _FraseDomainService.ExibirTodasFrasesPorTime(IdTime);
            var model = _mapper.Map<List<FraseGetModel>>(frase);
            return model;
        }
    }
}
