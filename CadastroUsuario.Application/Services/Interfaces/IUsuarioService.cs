using CadastroUsuario.Application.ViewModel;

namespace CadastroUsuario.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioViewModel> Get();
    }
}
