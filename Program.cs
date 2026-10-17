using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestASPNET.Api.Data;
using RestASPNET.Api.Model;
using RestASPNET.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");

builder.Services.AddDbContext<RestContext>(options =>
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

builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
