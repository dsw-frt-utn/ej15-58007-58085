using Dsw2026Ej15.Data.Persistence;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Api.Middlewares;

namespace Dsw2026Ej15.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ExceptionMiddleware>();

        app.MapGet("/health-check",()=>"ok");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}