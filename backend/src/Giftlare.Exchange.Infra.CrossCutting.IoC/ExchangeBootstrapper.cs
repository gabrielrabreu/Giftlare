using Giftlare.Exchange.Application.AppQueries;
using Giftlare.Exchange.Application.AppQueries.Interfaces;
using Giftlare.Exchange.Application.AppServices;
using Giftlare.Exchange.Application.AppServices.Interfaces;
using Giftlare.Exchange.Domain.Queries;
using Giftlare.Exchange.Domain.Repositories;
using Giftlare.Exchange.Infra.Data.Queries;
using Giftlare.Exchange.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Giftlare.Exchange.Infra.CrossCutting.IoC
{
    public static class ExchangeBootstrapper
    {
        public static void AddExchangeServices(this IServiceCollection services)
        {
            AppQueries(services);
            AppServices(services);
            Queries(services);
            Repositories(services);
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<IExchangeAppQuery, ExchangeAppQuery>();
        }

        public static void AppServices(IServiceCollection services)
        {
            services.AddScoped<IExchangeAppService, ExchangeAppService>();
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<IExchangeQuery, ExchangeQuery>();
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
        }
    }
}