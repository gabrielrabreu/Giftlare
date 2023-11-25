using Giftlare.Core.Domain.Security;
using Giftlare.Security.Application.Services;
using Giftlare.Security.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Giftlare.Security.Infra.CrossCutting.IoC
{
    public static class SecurityBootstrapper
    {
        public static void AddSecurityServices(this IServiceCollection services)
        {
            Services(services);
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}