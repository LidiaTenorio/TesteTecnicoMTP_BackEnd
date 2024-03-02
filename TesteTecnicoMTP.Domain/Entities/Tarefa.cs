using Microsoft.AspNetCore.Identity;

namespace TesteTecnicoMTP.Domain.Entities
{
    public class Tarefa 
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Concluido { get; set; }
        public bool Ativo { get; set; }
    }
}
