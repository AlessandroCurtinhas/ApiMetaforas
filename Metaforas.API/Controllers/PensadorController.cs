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
    public class PensadorController : ControllerBase
    {

        private readonly IPensadorApplicationService _pensadorApplicationService;

        public PensadorController(IPensadorApplicationService pensadorApplicationService)
        {
            _pensadorApplicationService = pensadorApplicationService;
        }
        
        [HttpPost]
        public IActionResult Post(PensadorPostModel model)
        {
            try
            {
                _pensadorApplicationService.Criar(model);
                return StatusCode(200, new { mensagem = "Pensador Criado com sucesso" });
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
        public  IActionResult Put(PensadorPutModel model)
        {
            try
            {
                _pensadorApplicationService.Atualizar(model);
                return StatusCode(204, new { mensagem = "Pensador Atualizado com sucesso" });
            }
            catch(ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        

        [ProducesResponseType(200, Type = typeof(PensadorGetModel))]
        [HttpGet("Usuario/{idUsuario}")]
        public  IActionResult GetByUsuario(Guid idUsuario)
        {
            try
            {
                var pensadores = _pensadorApplicationService.ExibirPensadorPorUsuario(idUsuario);
                return StatusCode(200, pensadores);

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

        [ProducesResponseType(200, Type = typeof(List<PensadorGetModel>))]
        [HttpGet]
        public  IActionResult GetAll()
        {
            try
            {
                var pensadores = _pensadorApplicationService.ExibirTodosPensadores();
                return StatusCode(200, pensadores);
                
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
        [ProducesResponseType(200, Type = typeof(PensadorGetModel))]
        [HttpGet("{idPensador}")]
        public IActionResult GetById(Guid idPensador)
        {
            try
            {
                var pensador = _pensadorApplicationService.ExbibirPensadorPorId(idPensador);
                return StatusCode(200, pensador);

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
