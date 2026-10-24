namespace RestASPNET.Api.Configurations;

using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

public static class EvolveConfig
{
    public static IServiceCollection AddEvolveConfiguration(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment enviroment)
    {
        if (enviroment.IsDevelopment())
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
           ?? throw new InvalidOperationException(
               "A string de conexão 'DefaultConnection' não foi encontrada."
           );

            try
            {
                using var evolveConnection = new SqlConnection(connectionString);
                var evolve = new Evolve(
                    evolveConnection, 
                    msg => Log.Information(msg))
                {
                    Locations = new[] { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao migrar o banco de dados.");
                throw;
            }
        }
        return services;
    }
}

