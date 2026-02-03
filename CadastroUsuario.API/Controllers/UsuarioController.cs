using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.Get();
            if (!usuarios.Any()) return NotFound(new { message = "Nenhum usuário cadastrado." });
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioInputModel input)
        {
            var usuarioId = _usuarioService.Post(input);
            return CreatedAtAction(nameof(GetById), new { id = usuarioId }, input);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] UsuarioInputModel input)
        {
            _usuarioService.Patch(id, input);
            return NoContent();
        }

        [HttpPatch("{id}/ativar")]
        public IActionResult Ativar(int id)
        {
            _usuarioService.Ativar(id);
            return NoContent();
        }

        [HttpPatch("{id}/desativar")]
        public IActionResult Desativar (int id)
        {
            _usuarioService.Desativar(id);
            return NoContent();
        }
    }
}
