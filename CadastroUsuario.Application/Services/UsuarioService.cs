using CadastroUsuario.Application.Services.Interfaces;
using CadastroUsuario.Application.ViewModel;
using CadastroUsuario.Infrastructure.Persistence;

namespace CadastroUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly CadastroUsuarioDbContext _context;

        public UsuarioService(CadastroUsuarioDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioViewModel> Get()
        {
            var usuariosViewModel = _context.Usuarios.Select(u =>
                new UsuarioViewModel(
                    u.Id,
                    u.NomeCompleto,
                    u.Email,
                    u.Cpf,
                    u.Telefone,
                    null, 
                    0
                )
            ).ToList();

            return usuariosViewModel;
        }
    }
}
