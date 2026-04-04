namespace CadastroUsuario.Application.ViewModel
{
    public class UsuarioCreatedViewModel
    {
        public UsuarioCreatedViewModel(int id, string nomeCompleto, string email, bool ativo)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            Ativo = ativo;
        }

        public int Id { get; }
        public string NomeCompleto { get; }
        public string Email { get; }
        public bool Ativo { get; }
    }
}
