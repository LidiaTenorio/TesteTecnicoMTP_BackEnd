using TesteTecnicoMTP.Application.Interfaces;
using TesteTecnicoMTP.Application.Mappings;
using TesteTecnicoMTP.Application.Services;
using TesteTecnicoMTP.Domain.Entities;
using TesteTecnicoMTP.Domain.Interfaces;
using TesteTecnicoMTP.Infra.Data.Context;
using TesteTecnicoMTP.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TesteTecnicoMTP.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                          .EnableRetryOnFailure(4, TimeSpan.FromSeconds(10), null)) // tentativas após erro de conexão
                    .EnableDetailedErrors());

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            #region SERVICES
            services.AddScoped<ITarefaService, TarefaService>();
            #endregion

            #region REPOSITORIES
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            #endregion

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("TesteTecnicoMTP.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
