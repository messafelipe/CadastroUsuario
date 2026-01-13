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
            
            if(!usuarios.Any()) return NotFound(new { message = "Nenhum usuário cadastrado."});

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioInputModel input)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, input);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            return NoContent();
        }
    }
}
