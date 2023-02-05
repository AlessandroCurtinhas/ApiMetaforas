using Metaforas.Application.Interfaces;
using Metaforas.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metaforas.API.Controllers
{
    [Authorize]
    [Route("metafora/[controller]")]
    [ApiController]
    public class FraseController : ControllerBase
    {
        private readonly IFraseApplicationService _fraseApplicationService;

        public FraseController(IFraseApplicationService fraseApplicationService)
        {
            _fraseApplicationService = fraseApplicationService;
        }

        [HttpPost]
        public IActionResult Post(FrasePostModel model)
        {
            try
            {
                _fraseApplicationService.Criar(model);
                return StatusCode(201, new { mensagem = "Frase criada com sucesso" });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(FrasePutModel model)
        {
            try
            {
                _fraseApplicationService.Atualizar(model);
                return StatusCode(200, new { mensagem = "Frase atualizada com sucesso" });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [ProducesResponseType(200, Type = typeof(FraseGetModel))]
        [HttpGet("{idFrase}")]
        public IActionResult GetById(Guid idFrase)
        {
            try
            {
                var frases = _fraseApplicationService.ExibirFrasePorId(idFrase);
                return StatusCode(200, frases);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }

        }
        [ProducesResponseType(200, Type = typeof(List<FraseGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var frases = _fraseApplicationService.ExibirTodasFrases();
                return StatusCode(200, frases);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }

        }

        [ProducesResponseType(200, Type = typeof(List<FraseGetModel>))]
        [HttpGet("pensador/{idPensador}")]
        public IActionResult GetByPensador(Guid idPensador)
        {
            try
            {
                var frases = _fraseApplicationService.ExibirFrasePorPensador(idPensador);
                return StatusCode(200, frases);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }

        }

        [ProducesResponseType(200, Type = typeof(List<FraseGetModel>))]
        [HttpGet("time/{idTime}")]
        public IActionResult GetByTime(Guid idTime)
        {
            try
            {
                var frases = _fraseApplicationService.ExibirTodasFrasesPorTime(idTime);
                return StatusCode(200, frases);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }

        }



    }
}
