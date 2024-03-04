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
        Task CadastrarTarefa(Tarefa tarefaDb);
        Task<Tarefa> BuscarTarefaPorId(Guid id);
        Task<IEnumerable<Tarefa>> BuscarTarefas();
        Task AtualizarTarefa(Tarefa tarefaDbNova);
        Task InativarTarefa(Guid id);
        Task ConcluirTarefa(Guid id);
        Task DeletarTarefa(Guid id);
    }
}
