using CadastroUsuario.Core.Enums;
using CadastroUsuario.Core.Exceptions;
using CadastroUsuario.Core.Validations;

namespace CadastroUsuario.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nomeCompleto, string email, string senhaHash, Genero genero, string cpf, DateTime dataNascimento, string telefone)
            : base()
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            SenhaHash = senhaHash;
            Genero = genero;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
            Ativo = true;

            Validacoes();
        }

        public string NomeCompleto { get; private set; }

        public string Email { get; private set; }

        public string SenhaHash { get; private set; }

        public Genero Genero { get; private set; }

        public string Cpf { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Telefone { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Update(
            string nomeCompleto, 
            string email, 
            string? senhaHash, 
            Genero genero, 
            string cpf,
            DateTime dataNascimento,
            string telefone)
        {
            NomeCompleto = nomeCompleto;
            Email = email;

            if (!string.IsNullOrEmpty(senhaHash))
                SenhaHash = senhaHash;

            Genero = genero;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;

            Validacoes();
        }

        public int CalcularIdade()
        {
            var hoje = DateTime.Today;

            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }

        private void Validacoes()
        {
            if (string.IsNullOrWhiteSpace(NomeCompleto))
                throw new DomainException("O nome completo é obrigatório.");
            if (string.IsNullOrWhiteSpace(Email))
                throw new DomainException("O email é obrigatório.");
            if (string.IsNullOrWhiteSpace(SenhaHash))
                throw new DomainException("A senha é obrigatória.");
            if (!CpfValidator.EhValido(Cpf))
                throw new DomainException("CPF inválido.");
        }
    }
}
