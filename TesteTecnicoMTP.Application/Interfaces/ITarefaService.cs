using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoMTP.Application.DTOs;

namespace TesteTecnicoMTP.Application.Interfaces
{
    public interface ITarefaService
    {
        Task CadastrarTarefa(TarefaDTO tarefa);
        Task<(IEnumerable<TarefaDTO>, int)> BuscarTarefas();
        Task<TarefaDTO> BuscarTarefaPorId(Guid id);
        Task AtualizarTarefa(TarefaDTO tarefa);
        Task InativarTarefa(Guid id);
        Task ConcluirTarefa(Guid id);
        Task DeletarTarefa(Guid id);
    }
}
