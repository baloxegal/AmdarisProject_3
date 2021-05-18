using AmdarisProject_3.RegAndAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly AuthenticationContext _authenticationContext;

        public ValuesController(AuthenticationContext authenticationContext, ILogger<ValuesController> logger)
        {
            _authenticationContext = authenticationContext;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {            
            return new string[] { "values_1", "values_2" };
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "values_id = " + id;
        }
    }
}
