using CadastroUsuario.Core.Entities;
using CadastroUsuario.Core.Repositories.Interfaces;

namespace CadastroUsuario.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly CadastroUsuarioDbContext _context;

        public UsuarioRepository(CadastroUsuarioDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario usuario)
        {
            _context.SaveChanges();
        }
    }
}
