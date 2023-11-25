namespace Giftlare.WebApi.Scope.Extensions
{
    public static class CorsServiceCollectionExtensions
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options.AddPolicy("AllowLocalhost3000",
                        builder => builder.WithOrigins("http://localhost:3000")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials());
                });
        }

        public static void UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors("AllowLocalhost3000");
        }
    }
}
