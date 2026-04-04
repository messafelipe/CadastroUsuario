using CadastroUsuario.Application.InputModel;
using CadastroUsuario.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioService.GetAll();
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
            var usuario = _usuarioService.Post(input);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
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
