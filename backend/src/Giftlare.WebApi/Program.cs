using Giftlare.WebApi.Scope.Extensions;
using Giftlare.WebApi.Scope.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomControllers();
builder.Services.AddCustomVersioning();
builder.Services.AddCustomDatabase();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomServices();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomCors();

builder.Logging.AddCustomLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseCustomCors();
app.UseCustomAuthentication();
app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
