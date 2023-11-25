using Giftlare.Core.Domain.Extensions;
using Giftlare.Core.Domain.Security;
using Giftlare.Infra.DbEntities;
using Giftlare.Security.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace Giftlare.WebApi.Scope.Filters
{
    public class SessionActionFilter : IActionFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISessionService _sessionService;

        public SessionActionFilter(UserManager<ApplicationUser> userManager,
                                   ISessionService sessionService)
        {
            _userManager = userManager;
            _sessionService = sessionService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Language", out var languageHeaderValue);
            ConfigureCulture(languageHeaderValue.FirstOrDefault()?.ToString() ?? "en-US");

            var identity = context.HttpContext.User.Identity;

            if (identity != null && identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(context.HttpContext.User).Result;
                if (user != null)
                {
                    _sessionService.Authenticate(new AuthenticatedUser()
                    {
                        Id = user.Id,
                        Name = user.Name ?? string.Empty,
                        Email = user.Email ?? string.Empty,
                        Language = user.Language.GetEnumDisplayDescription()
                    });
                    ConfigureCulture(user.Language.GetEnumDisplayDescription());
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        private static void ConfigureCulture(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
