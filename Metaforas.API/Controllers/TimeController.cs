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
    public class TimeController : ControllerBase
    {
        private readonly ITimeApplicationService _timeApplicationService;

        public TimeController(ITimeApplicationService timeApplicationService)
        {
            _timeApplicationService = timeApplicationService;
        }

        [HttpPost]
        public IActionResult Post(TimePostModel model)
        {
            try
            {
                _timeApplicationService.Criar(model);
                return StatusCode(201, new { mensagem = "Time criado com sucesso" });
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
        public  IActionResult Put(TimePutModel model)
        {
            try
            {
                _timeApplicationService.Atualizar(model);
                return StatusCode(200, new { mensagem = "Time atualizado com sucesso" });
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
        [ProducesResponseType(200, Type = typeof(TimeGetModel))]
        [HttpGet("{idTime}")]
        public IActionResult GetById(Guid idTime)
        {
            try
            {
                var time = _timeApplicationService.ExibirTimePorId(idTime);
                return StatusCode(200, time);
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
        [ProducesResponseType(200, Type = typeof(List<TimeGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var times = _timeApplicationService.ExibirTodosTimes();
                return StatusCode(200,times);
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
