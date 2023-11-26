using Giftlare.Main.Application.AppQueries;
using Giftlare.Main.Application.AppQueries.Interfaces;
using Giftlare.Main.Application.AppServices;
using Giftlare.Main.Application.AppServices.Interfaces;
using Giftlare.Main.Domain.Queries;
using Giftlare.Main.Domain.Repositories;
using Giftlare.Main.Infra.Data.Repositories;
using Giftlare.Main.Infra.Repository.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Giftlare.Main.Infra.CrossCutting.IoC
{
    public static class MainBootstrapper
    {
        public static void AddMainServices(this IServiceCollection services)
        {
            AppQueries(services);
            AppServices(services);
            Queries(services);
            Repositories(services);
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<IGatheringAppQuery, GatheringAppQuery>();
        }

        public static void AppServices(IServiceCollection services)
        {
            services.AddScoped<IGatheringAppService, GatheringAppService>();
            services.AddScoped<IInvitationAppService, InvitationAppService>();
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<IGatheringQuery, GatheringQuery>();
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IGatheringRepository, GatheringRepository>();
        }
    }
}
