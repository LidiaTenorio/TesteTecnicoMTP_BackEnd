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

        public async Task<(IEnumerable<TarefaDTO>, int)> BuscarTarefas(int skip, int take)
        {
            try
            {
                var tarefasDb = await _tarefaRepository.BuscarTarefas();
                var tarefasDTO = _mapper.Map<IEnumerable<TarefaDTO>>(tarefasDb).ToList();
                var tarefasDTOPaginado = tarefasDTO.Skip(skip).Take(take);
                return (tarefasDTOPaginado, tarefasDTO.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar tarefa: {ex.Message}");
                throw;
            }
            
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
    }
}
