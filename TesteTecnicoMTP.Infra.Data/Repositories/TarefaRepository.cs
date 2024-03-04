using TesteTecnicoMTP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoMTP.Domain.Entities;
using TesteTecnicoMTP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TesteTecnicoMTP.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private ApplicationDbContext _context;
        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarTarefa(Tarefa tarefaDb)
        {
            await _context.Tarefas.AddAsync(tarefaDb);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Tarefa>> BuscarTarefas()
        {
            var tarefas = await _context.Tarefas.Where(t => t.Ativo).OrderByDescending(x => x.DataCadastro).ToListAsync();
            return tarefas;
        }

        public async Task<Tarefa> BuscarTarefaPorId(Guid id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id && t.Ativo);
            if (tarefa == null)
                throw new InvalidOperationException("Tarefa não encontrada!");

            return tarefa;
        }

        public async Task AtualizarTarefa(Tarefa tarefaDb)
        {
            var tarefa = await BuscarTarefaPorId(tarefaDb.Id);

            tarefa.Descricao = tarefaDb.Descricao;
            tarefa.DataAtualizacao = DateTime.Now;

            _context.Update(tarefa);
            await _context.SaveChangesAsync();
        }
        public async Task InativarTarefa(Guid id)
        {
            var tarefa = await BuscarTarefaPorId(id);

            tarefa.Ativo = false;
            tarefa.DataAtualizacao = DateTime.Now;

            _context.Update(tarefa);
            await _context.SaveChangesAsync();
        }
        public async Task ConcluirTarefa(Guid id)
        {
            var tarefa = await BuscarTarefaPorId(id);

            tarefa.Concluido = true;
            tarefa.DataAtualizacao = DateTime.Now;

            _context.Update(tarefa);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarTarefa(Guid id)
        {
            var tarefa = await BuscarTarefaPorId(id);

            _context.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
