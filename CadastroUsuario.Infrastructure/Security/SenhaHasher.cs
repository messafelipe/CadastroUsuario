using CadastroUsuario.Core.Security.Interfaces;

namespace CadastroUsuario.Infrastructure.Security
{
    public class SenhaHasher : ISenhaHasher
    {
        public string Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool Verify(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
