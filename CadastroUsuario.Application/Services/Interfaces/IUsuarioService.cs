using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.ViewModel;

namespace CadastroUsuario.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioListViewModel> Get();
        int Post(UsuarioInputModel input);
        UsuarioDetailViewModel GetById(int id);
        void Patch(int id, UsuarioInputModel input);
        void Ativar(int id);
        void Desativar(int id);
    }
}
