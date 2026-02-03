using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.Services.Interfaces;
using CadastroUsuario.Application.ViewModel;
using CadastroUsuario.Core.Entities;
using CadastroUsuario.Core.Repositories.Interfaces;
using CadastroUsuario.Core.Security.Interfaces;

namespace CadastroUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHasher _senhaHasher;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            ISenhaHasher senhaHasher)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHasher = senhaHasher;
        }

        public IEnumerable<UsuarioListViewModel> Get()
        {
            var usuarios = _usuarioRepository.GetAll();

            return usuarios.Select(u =>
                new UsuarioListViewModel(
                    id: u.Id,
                    nomeCompleto: u.NomeCompleto,
                    email: u.Email
                ));
        }

        public UsuarioDetailViewModel GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            var usuarioViewModel = new UsuarioDetailViewModel(
                id: usuario.Id,
                nomeCompleto: usuario.NomeCompleto,
                email: usuario.Email,
                cpf: usuario.Cpf,
                dataNascimento: usuario.DataNascimento,
                telefone: usuario.Telefone,
                generoDescricao: usuario.Genero.ToString(),
                idade: usuario.CalcularIdade()
            );

            return usuarioViewModel;
        }

        public int Post(UsuarioInputModel input)
        {
            if (input.Senha != input.ConfirmarSenha)
                throw new Exception("As senhas não conferem.");

            var senhaHash = _senhaHasher.Hash(input.Senha);

            var usuario = new Usuario(
                nomeCompleto: input.NomeCompleto,
                email: input.Email,
                senhaHash: senhaHash,
                genero: input.Genero,
                cpf: input.Cpf,
                dataNascimento: input.DataNascimento,
                telefone: input.Telefone
            );

            _usuarioRepository.Add(usuario);

            return usuario.Id;
        }

        public void Ativar(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            usuario.Ativar();

            _usuarioRepository.Update(usuario);
        }

        public void Desativar(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            usuario.Desativar();

            _usuarioRepository.Update(usuario);
        }

        public void Patch(int id, UsuarioInputModel input)
        {
            var usuario = _usuarioRepository.GetById(id);

            string? senhaHash = null;

            if (!string.IsNullOrWhiteSpace(input.Senha))
            {
                if (input.Senha != input.ConfirmarSenha)
                    throw new Exception("As senhas não conferem.");

                senhaHash = _senhaHasher.Hash(input.Senha);
            }

            usuario.Update
            (
                nomeCompleto: input.NomeCompleto,
                email: input.Email,
                senhaHash: senhaHash,
                genero: input.Genero,
                cpf: input.Cpf,
                dataNascimento: input.DataNascimento,
                telefone: input.Telefone
            );

            _usuarioRepository.Update(usuario);
        }
    }
}
