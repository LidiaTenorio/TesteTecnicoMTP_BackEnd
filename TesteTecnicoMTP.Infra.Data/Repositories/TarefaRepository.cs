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

        public async Task<IEnumerable<Tarefa>> BuscarTarefas()
        {
            var tarefas = await _context.Tarefas.Where(t => t.Ativo).OrderByDescending(x => x.DataCadastro).ToListAsync();
            return tarefas;
        }

        public async Task CadastrarTarefa(Tarefa tarefaDb)
        {
            await _context.Tarefas.AddAsync(tarefaDb);
            _context.SaveChanges();

        }

        public async Task<Tarefa> BuscarTarefaPorId(Guid id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            return tarefa;
        }

        public async Task AtualizarTarefa(Tarefa tarefaDbNova)
        {
            var tarefaDb = await BuscarTarefaPorId((Guid)tarefaDbNova.Id);

            if (tarefaDb == null)
                throw new InvalidOperationException("Tarefa não encontrada!");

            try
            {
                if (_context.Entry(tarefaDb).State != EntityState.Detached)
                {
                    tarefaDb.DataAtualizacao = DateTime.Now;
                    tarefaDb.Concluido = tarefaDbNova.Concluido;
                    tarefaDb.Descricao = tarefaDbNova.Descricao;
                    tarefaDb.Ativo = tarefaDbNova.Ativo;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Attach(tarefaDb);
                    tarefaDb.DataAtualizacao = DateTime.Now;
                    tarefaDb.Descricao = tarefaDbNova.Descricao;
                    tarefaDb.Concluido = tarefaDbNova.Concluido;
                    tarefaDb.Ativo = tarefaDbNova.Ativo;
                    _context.Update(tarefaDb);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
