using Aplicacao.Services;
using Dominio.Interface;
using Infraestrutura.Context;
using Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TarefaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TarefasDatabase"),
        b => b.MigrationsAssembly("API")));

builder.Services.AddScoped<IServicoTarefa, ServicoTarefa>();
builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
