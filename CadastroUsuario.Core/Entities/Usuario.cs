namespace CadastroUsuario.Core.Entities
{
    public class Usuario
    {
        public Usuario(string nomeCompleto, string email, string senha, int genero, string cpf, DateTime dataNascimento, string telefone)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            Genero = genero;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public int Id { get; private set; }

        public string NomeCompleto { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public int Genero { get; private set; }

        public string Cpf { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Telefone { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; private set; }
    }
}
