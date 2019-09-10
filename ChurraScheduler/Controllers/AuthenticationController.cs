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
        // POST api/Churras/List
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<IEnumerable<string>> Authenticate([FromBody] Usuario userAuth)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
