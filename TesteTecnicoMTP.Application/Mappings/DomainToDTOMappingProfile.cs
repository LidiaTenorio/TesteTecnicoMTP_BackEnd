using AutoMapper;
using TesteTecnicoMTP.Application.DTOs;
using TesteTecnicoMTP.Domain.Entities;

namespace TesteTecnicoMTP.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
        }
    }
}
