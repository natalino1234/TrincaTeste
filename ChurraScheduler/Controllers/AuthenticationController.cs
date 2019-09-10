using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace ChurraScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        List<string> teste = new List<string>();

        // POST api/Churras/List
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<IEnumerable<string>> Authenticate([FromBody] Usuario userAuth)
        {
            /*Fazer alguma coisa de autenticação OAuth2*/
            return new string[] { "value1", "value2" };
        }
    }
}