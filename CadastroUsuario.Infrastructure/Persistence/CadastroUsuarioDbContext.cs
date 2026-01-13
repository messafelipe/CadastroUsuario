using CadastroUsuario.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infrastructure.Persistence
{
    public class CadastroUsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
