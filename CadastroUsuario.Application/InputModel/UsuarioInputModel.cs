using CadastroUsuario.Core.Enums;

namespace CadastroUsuario.Application.InputModel
{
    public class UsuarioInputModel
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string ConfirmarSenha { get; set; }

        public Genero Genero { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }
    }
}
