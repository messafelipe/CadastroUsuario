using CadastroUsuario.Application.Services;
using CadastroUsuario.Application.Services.Interfaces;
using CadastroUsuario.Core.Repositories.Interfaces;
using CadastroUsuario.Core.Security.Interfaces;
using CadastroUsuario.Infrastructure.Persistence;
using CadastroUsuario.Infrastructure.Persistence.Repositories;
using CadastroUsuario.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<CadastroUsuarioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
