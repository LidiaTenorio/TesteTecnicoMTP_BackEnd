using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoMTP.Domain.Entities;

namespace TesteTecnicoMTP.Infra.Data.EntititesConfiguration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.DataCadastro)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(t => t.Concluido)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.Ativo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(t => t.DataAtualizacao)
                .IsRequired(false);
        }
    }

}


