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
    public class ChurrasController : ControllerBase
    {
        // POST api/Churras/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult<IEnumerable<string>> CreateChurras([FromBody] Usuario userAuth, [FromBody] Churras churras)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/Churras/Cancel
        [HttpPost]
        [Route("Cancel")]
        public ActionResult<IEnumerable<string>> CancelChurras([FromBody] Churras churras)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/Churras/List
        [HttpPost]
        [Route("List")]
        public ActionResult<IEnumerable<string>> ListChurras([FromBody] Usuario userAuth, [FromBody] Churras churras)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/Churras/Edit
        [HttpPost]
        [Route("List")]
        public ActionResult<IEnumerable<string>> EditChurras([FromBody] Usuario userAuth, [FromBody] Churras churras)
        {
            return new string[] { "value1", "value2" };
        }

    }
}
