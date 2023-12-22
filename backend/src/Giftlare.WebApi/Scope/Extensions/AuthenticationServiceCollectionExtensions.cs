using Azure;
using Giftlare.Infra.DbContext;
using Giftlare.Infra.DbEntities;
using Giftlare.Infra.Resources;
using Giftlare.Security.Application.Settings;
using Giftlare.WebApi.Scope.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Giftlare.WebApi.Scope.Extensions
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authSettingsSection = configuration.GetSection("AuthSettings");
            services.Configure<AuthSettings>(authSettingsSection);

            var authSettings = GetAuthSettings(authSettingsSection.Get<AuthSettings>());

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authSettings.Issuer,
                        ValidAudience = authSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Secret))
                    };

                    x.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception is SecurityTokenExpiredException)
                            {
                                context.Response.StatusCode = 401;
                                context.Response.OnStarting(() =>
                                {
                                    var response = new ErrorResponseDto
                                    {
                                        Type = "AuthenticationFailedError",
                                        Error = "AuthenticationFailedError",
                                        Detail = GiftlareResource.ExpiredToken,
                                        Instance = context.Request.Path.Value,
                                        TraceId = Activity.Current?.TraceId.ToString()
                                    };
                                    context.Response.ContentType = "application/json";
                                    return context.Response.WriteAsync(response.Serialize());
                                });
                            }
                            else
                            {
                                context.Response.StatusCode = 401;
                                context.Response.OnStarting(() =>
                                {
                                    var response = new ErrorResponseDto
                                    {
                                        Type = "AuthenticationFailedError",
                                        Error = "AuthenticationFailedError",
                                        Detail = GiftlareResource.InvalidToken,
                                        Instance = context.Request.Path.Value,
                                        TraceId = Activity.Current?.TraceId.ToString()
                                    };
                                    context.Response.ContentType = "application/json";
                                    return context.Response.WriteAsync(response.Serialize());
                                });
                            }
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.OnStarting(() =>
                            {
                                var response = new ErrorResponseDto
                                {
                                    Type = "AuthorizationFailedError",
                                    Error = "AuthorizationFailedError",
                                    Detail = GiftlareResource.UnauthorizedAccess,
                                    Instance = context.Request.Path.Value,
                                    TraceId = Activity.Current?.TraceId.ToString()
                                };
                                context.Response.ContentType = "application/json";
                                return context.Response.WriteAsync(response.Serialize());
                            });
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void UseCustomAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        private static AuthSettings GetAuthSettings(AuthSettings? authSettings)
        {
            if (authSettings == null)
                throw new ArgumentNullException(nameof(authSettings), "AuthSettings section not found.");
            return authSettings;
        }
    }
}
