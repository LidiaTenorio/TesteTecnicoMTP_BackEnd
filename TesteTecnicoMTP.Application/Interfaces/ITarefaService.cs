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
        Task AtualizarTarefa(TarefaDTO tarefa);
        Task<TarefaDTO> BuscarTarefaPorId(Guid id);
        Task<(IEnumerable<TarefaDTO>, int)> BuscarTarefas(int skip, int take);
        Task CadastrarTarefa(TarefaDTO tarefa);
    }
}
