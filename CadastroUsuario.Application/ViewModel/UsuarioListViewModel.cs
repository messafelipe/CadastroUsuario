namespace CadastroUsuario.Application.ViewModel
{
    public class UsuarioListViewModel
    {
        public UsuarioListViewModel(
            int id, 
            string nomeCompleto, 
            string email
        )
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
        }

        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }
    }
}
