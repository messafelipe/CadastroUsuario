namespace CadastroUsuario.Application.ViewModel
{
    public class UsuarioDetailViewModel
    {
        public UsuarioDetailViewModel(
            int id, 
            string nomeCompleto, 
            string email, 
            string cpf,
            string telefone,
            DateTime dataNascimento,
            string? generoDescricao = default,
            int idade = default
        )
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            GeneroDescricao = generoDescricao ?? string.Empty;
            Idade = idade;
        }

        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string GeneroDescricao { get; set; }

        public int Idade { get; set; }
    }
}
