using TesteTecnicoMTP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoMTP.Infra.Data.EntititesConfiguration;

namespace TesteTecnicoMTP.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.ApplyConfiguration(new TarefaConfiguration());
        }
    }

}




