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
    }
}
