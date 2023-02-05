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
    public class PensadorTimeController : ControllerBase
    {
        private readonly IPensadorTimeApplicationService _pensadorTimeApplicationService;

        public PensadorTimeController(IPensadorTimeApplicationService pensadorTimeApplicationService)
        {
            _pensadorTimeApplicationService = pensadorTimeApplicationService;
        }

        [HttpPost]
        public IActionResult Post(PensadorTimePostModel model)
        {
            try
            {
                _pensadorTimeApplicationService.Criar(model);
                return StatusCode(201, new { mensagem = "Alocação do pensador criada com sucesso" });
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
        public IActionResult Put(PensadorTimePutModel model)
        {
            try
            {
                _pensadorTimeApplicationService.Atualizar(model);
                return StatusCode(200, new { mensagem = "Alocação do pensador atualizada com sucesso" });
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

        [ProducesResponseType(200, Type = typeof(List<PensadorTimeGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var pensadorTimes = _pensadorTimeApplicationService.ExibirTodosPensadoresTime();
                return StatusCode(200, pensadorTimes);
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

        [ProducesResponseType(200, Type = typeof(PensadorTimeGetModel))]
        [HttpGet("{idPensadorTime}")]
        public IActionResult GetById(Guid idPensadorTime)
        {
            try
            {
                var pensadorTimes = _pensadorTimeApplicationService.ExibirPensandorTimePorId(idPensadorTime);
                return StatusCode(200, pensadorTimes);
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

        [ProducesResponseType(200, Type = typeof(List<PensadorTimeGetModel>))]
        [HttpGet("time/{idTime}")]
        public IActionResult GetByTime(Guid idTime)
        {
            try
            {
                var pensadorTimes = _pensadorTimeApplicationService.ExibirPensadorTimePorTime(idTime);
                return StatusCode(200, pensadorTimes);
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
        [ProducesResponseType(200, Type = typeof(List<PensadorTimeGetModel>))]
        [HttpGet("pensador/{idPensador}")]
        public IActionResult GetByPensador(Guid idPensador)
        {
            try
            {
                var pensadorTimes = _pensadorTimeApplicationService.ExibirPensadorPorPensador(idPensador);
                return StatusCode(200, pensadorTimes);
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
