using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoMTP.Domain.Entities;

namespace TesteTecnicoMTP.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task AtualizarTarefa(Tarefa tarefaDbNova);
        Task<Tarefa> BuscarTarefaPorId(Guid id);
        Task<IEnumerable<Tarefa>> BuscarTarefas();
        Task CadastrarTarefa(Tarefa tarefaDb);
    }
}
