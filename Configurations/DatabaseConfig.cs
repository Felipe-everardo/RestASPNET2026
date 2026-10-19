using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestASPNET.Api.Data;

namespace RestASPNET.Api.Extensions;

public static class DatabaseServiceCollectionExtensions
{

    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "A string de conexão 'DefaultConnection' não foi encontrada."
            );

        services.AddDbContext<MSSQLContext>(options =>
{
    options.UseSqlServer(connectionString, sqlServerOptions =>
    {
        // Ativa a reexecução automática em caso de falhas transitórias (quedas rápidas de rede)
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                  // Número máximo de tentativas
            maxRetryDelay: TimeSpan.FromSeconds(30), // Tempo máximo de espera entre tentativas
            errorNumbersToAdd: null            // Códigos de erro SQL adicionais para tratar
        );
    });
});

        return services;
    }
}