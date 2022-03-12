using BikeSocialBLL.Testes;
using Microsoft.AspNetCore.Mvc;

namespace BikeSocialAPI.Controllers
{
    [Route("bikesocial/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly ITeste _teste;

        public RegistrationController(ITeste teste)
        {
            _teste = teste;
        }

       [HttpPost("AddUser/{name}")]
       public async Task<IActionResult> RegisterUser(string name)
       {
            await _teste.Add(name);
            return Ok();
       }
    }
}
