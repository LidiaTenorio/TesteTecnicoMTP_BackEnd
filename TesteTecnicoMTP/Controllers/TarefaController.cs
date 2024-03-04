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

        #region POST
        [ProducesResponseType(500)]
        [HttpPost()]
        public async Task<ActionResult> CadastrarTarefa(TarefaDTO tarefa)
        {
            try
            {
                await _tarefaService.CadastrarTarefa(tarefa);
                return Ok(new { message = "Tarefa cadastrada com sucesso!" });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, "Erro ao cadastrar tarefas: " + ex.Message);
            }
        }
        #endregion

        #region GET
        [ProducesResponseType(500)]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> BuscarTarefas()
        {
            try
            {
                var tarefas = await _tarefaService.BuscarTarefas();

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
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar tarefa por Id: " + ex.Message);
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
                return Ok(new { message = "Tarefa atualizada com sucesso!"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao atualizar tarefas: " + ex.Message);
            }
        }

        [ProducesResponseType(500)]
        [HttpPut("InativarTarefa")]
        public async Task<ActionResult> InativarTarefa(Guid id)
        {
            try
            {
                await _tarefaService.InativarTarefa(id);
                return Ok(new { message = "Tarefa inativada com sucesso!"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao inativar tarefas: " + ex.Message);
            }
        }

        [ProducesResponseType(500)]
        [HttpPut("ConcluirTarefa")]
        public async Task<ActionResult> ConcluirTarefa(Guid id)
        {
            try
            {
                await _tarefaService.ConcluirTarefa(id);
                return Ok(new { message = "Tarefa concluida com sucesso!"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao concluir tarefas: " + ex.Message);
            }
        }
        #endregion

        #region DELETE
        [ProducesResponseType(500)]
        [HttpDelete()]
        public async Task<ActionResult> DeletarTarefa(Guid id)
        {
            try
            {
                await _tarefaService.DeletarTarefa(id);
                return Ok(new { message = "Tarefa Deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao deletar tarefas: " + ex.Message);
            }
        }
        #endregion
    }
}
