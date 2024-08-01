using Investimento.Application._1._1_Interface;
using Investimento.Application._1._2_AppService;
using Investimento.Domain._2._1_Interface;
using Investimento.Domain.Notifications;
using Investimento.Infra._3._1_Context;
using Investimento.Infrastructure._3._3_Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Investimento.Infra.CrossCutting.Ioc
{
    public static class BootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) 
        {   
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionRepository, PositionRepository>();            

            services.AddScoped<InvestimentoContext>();

            return services;
        }
    }
}
