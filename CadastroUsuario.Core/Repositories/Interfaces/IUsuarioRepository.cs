using CadastroUsuario.Core.Entities;

namespace CadastroUsuario.Core.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        void Add(Usuario usuario);
        Usuario GetById(int id);
        void Update(Usuario usuario);
    }
}
