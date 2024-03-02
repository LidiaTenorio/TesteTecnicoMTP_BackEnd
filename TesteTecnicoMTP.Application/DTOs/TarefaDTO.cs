using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoMTP.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Concluido { get; set; }
        public bool? Ativo { get; set; }
    }
}
