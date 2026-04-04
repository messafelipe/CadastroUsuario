namespace CadastroUsuario.Core.Validations
{
    public static class CpfValidator
    {
        public static bool EhValido(string cpf)
        {
            cpf = SomenteNumeros(cpf);

            if (cpf.Length != 11)
                return false;

            return true;
        }

        public static string SomenteNumeros(string cpf)
            => new(cpf.Where(char.IsDigit).ToArray());
    }
}
