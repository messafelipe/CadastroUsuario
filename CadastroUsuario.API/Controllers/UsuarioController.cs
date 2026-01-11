using CadastroUsuario.Application.InputModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
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
