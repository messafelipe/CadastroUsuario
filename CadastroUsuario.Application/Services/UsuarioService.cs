using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.Services.Interfaces;
using CadastroUsuario.Application.ViewModel;
using CadastroUsuario.Core.Entities;
using CadastroUsuario.Core.Exceptions;
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

        public IEnumerable<UsuarioListViewModel> GetAll()
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

            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado");

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

        public UsuarioCreatedViewModel Post(UsuarioInputModel input)
        {
            if (input.Senha != input.ConfirmarSenha)
                throw new DomainException("As senhas não conferem.");

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

            return new UsuarioCreatedViewModel
            (
                usuario.Id,
                usuario.NomeCompleto,
                usuario.Email,
                usuario.Ativo
            );
        }

        public void Patch(int id, UsuarioInputModel input)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado");

            string? senhaHash = null;

            if (!string.IsNullOrWhiteSpace(input.Senha))
            {
                if (input.Senha != input.ConfirmarSenha)
                    throw new DomainException("As senhas não conferem.");

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
    }
}
