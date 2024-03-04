using TesteTecnicoMTP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteTecnicoMTP.Domain.Interfaces;
using TesteTecnicoMTP.Domain.Entities;
using TesteTecnicoMTP.Application.DTOs;

namespace TesteTecnicoMTP.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task CadastrarTarefa(TarefaDTO tarefa)
        {
            try
            {
                var tarefaDb = _mapper.Map<Tarefa>(tarefa);
                await _tarefaRepository.CadastrarTarefa(tarefaDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar tarefa: {ex.Message}");
                throw;
            }
        }

        public async Task<(IEnumerable<TarefaDTO>, int)> BuscarTarefas()
        {
            try
            {
                var tarefasDb = await _tarefaRepository.BuscarTarefas();
                var tarefasDTO = _mapper.Map<IEnumerable<TarefaDTO>>(tarefasDb).ToList();
                return (tarefasDTO, tarefasDTO.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa: {ex.Message}");
                throw;
            }
        }

        public async Task<TarefaDTO> BuscarTarefaPorId(Guid id)
        {
            try
            {
                var tarefaDb = await _tarefaRepository.BuscarTarefaPorId(id);
                var tarefasDTO = _mapper.Map<TarefaDTO>(tarefaDb);
                return tarefasDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa por Id: {ex.Message}");
                throw;
            }
        }

        public async Task AtualizarTarefa(TarefaDTO tarefa)
        {
            try
            {
                var tarefaDbNova = _mapper.Map<Tarefa>(tarefa);
                await _tarefaRepository.AtualizarTarefa(tarefaDbNova);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar tarefa: {ex.Message}");
                throw;
            }
        }

        public async Task InativarTarefa(Guid id)
        {
            try
            {
                await _tarefaRepository.InativarTarefa(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa por Id: {ex.Message}");
                throw;
            }
        }

        public async Task ConcluirTarefa(Guid id)
        {
            try
            {
                await _tarefaRepository.ConcluirTarefa(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa por Id: {ex.Message}");
                throw;
            }
        }

        public async Task DeletarTarefa(Guid id)
        {
            try
            {
                await _tarefaRepository.DeletarTarefa(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa por Id: {ex.Message}");
                throw;
            }
        }

    }
}
