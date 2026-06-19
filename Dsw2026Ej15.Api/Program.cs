using Dsw2026Ej15.Data.Persistence;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        // ↓ Registrar PersistenceInMemory como Singleton
        builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}