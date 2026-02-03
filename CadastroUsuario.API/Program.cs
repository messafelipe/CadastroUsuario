using CadastroUsuario.Application.Services;
using CadastroUsuario.Application.Services.Interfaces;
using CadastroUsuario.Core.Security.Interfaces;
using CadastroUsuario.Infrastructure.Persistence;
using CadastroUsuario.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<CadastroUsuarioDbContext>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();

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
