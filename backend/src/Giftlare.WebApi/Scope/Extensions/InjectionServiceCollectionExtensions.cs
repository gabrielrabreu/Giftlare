using Giftlare.Exchange.Infra.CrossCutting.IoC;
using Giftlare.Security.Infra.CrossCutting.IoC;
using Giftlare.WebApi.Scope.Middlewares;

namespace Giftlare.WebApi.Scope.Extensions
{
    public static class InjectionServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddSecurityServices();
            services.AddExchangeServices();
        }
    }
}
