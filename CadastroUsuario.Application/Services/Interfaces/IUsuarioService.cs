using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.ViewModel;

namespace CadastroUsuario.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioListViewModel> GetAll();
        UsuarioDetailViewModel GetById(int id);
        UsuarioCreatedViewModel Post(UsuarioInputModel input);
        void Patch(int id, UsuarioInputModel input);
        void Ativar(int id);
        void Desativar(int id);
    }
}
