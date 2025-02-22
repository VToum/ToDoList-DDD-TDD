using Aplicacao.Services;
using Dominio.Interface;
using Infraestrutura.Context;
using Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TarefaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TarefasDatabase"),
    b => b.MigrationsAssembly("ToDoList-DDD-TDD"))); // Certifique-se que o nome da assembly esteja correto

builder.Services.AddScoped<IServicoTarefa, ServicoTarefa>();
builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseMiddleware<MiddlewareTratamentoErros>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
