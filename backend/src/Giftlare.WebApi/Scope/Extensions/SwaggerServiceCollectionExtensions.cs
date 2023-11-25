using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Giftlare.WebApi.Scope.Extensions
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = "Giftlare",
                        Version = description.ApiVersion.ToString()
                    });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                }
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
                var versionNames = provider.ApiVersionDescriptions.Select(description => description.GroupName.ToUpperInvariant());
                foreach (var versionName in versionNames)
                {
                    options.SwaggerEndpoint($"/swagger/{versionName}/swagger.json", versionName);
                }
            });
        }
    }
}
