using Microsoft.AspNetCore.Mvc;
using TesteTecnicoMTP.Application.DTOs;
using TesteTecnicoMTP.Application.Interfaces;
using TesteTecnicoMTP.Domain.Interfaces;

namespace TesteTecnicoMTP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        #region GET

        [ProducesResponseType(500)]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> BuscarTarefas(int skip = 0, int take = 20)
        {
            try
            {
                var tarefas = await _tarefaService.BuscarTarefas(skip, take);

                if(tarefas.Item1 == null)
                    return NotFound("Nenhum tarefa encontrada!");

                return Ok(new {Tarefas = tarefas.Item1, Total = tarefas.Item2});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefas: " + ex.Message);
            }
        }

        [ProducesResponseType(500)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<TarefaDTO>> BuscarTarefaPorId(Guid id)
        {
            try
            {
                var tarefa = await _tarefaService.BuscarTarefaPorId(id);

                if (tarefa == null)
                    return NotFound("Tarefa não encontrada!");

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefas: " + ex.Message);
            }
        }

        #endregion

        #region POST
        [ProducesResponseType(500)]
        [HttpPost()]
        public async Task<ActionResult> CadastrarTarefa(TarefaDTO tarefa)
        {
            try
            {
                await _tarefaService.CadastrarTarefa(tarefa);
                return Ok("Tarefa cadastrada com sucesso!");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region PUT
        [ProducesResponseType(500)]
        [HttpPut()]
        public async Task<ActionResult> AtualizarTarefa(TarefaDTO tarefa)
        {
            try
            {
                await _tarefaService.AtualizarTarefa(tarefa);
                return Ok("Tarefa atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefas: " + ex.Message);
            }
        }

        [ProducesResponseType(500)]
        [HttpPut("InativarTarefa")]
        public async Task<ActionResult> InativarTarefa(Guid id)
        {
            try
            {
                var tarefaDb = await _tarefaService.BuscarTarefaPorId(id);

                if (tarefaDb == null)
                    return NotFound("Tarefa não encontrada!");

                tarefaDb.Ativo = false;

                await _tarefaService.AtualizarTarefa(tarefaDb);
                return Ok("Tarefa atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefas: " + ex.Message);
            }
        }

        [ProducesResponseType(500)]
        [HttpPut("ConcluirTarefa")]
        public async Task<ActionResult> ConcluirTarefa(Guid id)
        {
            try
            {
                var tarefaDb = await _tarefaService.BuscarTarefaPorId(id);

                if (tarefaDb == null)
                    return NotFound("Tarefa não encontrada!");

                tarefaDb.Concluido = true;

                await _tarefaService.AtualizarTarefa(tarefaDb);
                return Ok("Tarefa atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefas: " + ex.Message);
            }
        }
        #endregion

    }
}
