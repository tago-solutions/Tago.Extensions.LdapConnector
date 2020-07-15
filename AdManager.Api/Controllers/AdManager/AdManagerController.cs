using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tago.Ldap;
using Tago.Ldap.AdUtils;

namespace AdManager.Api.Controllers
{
    [ApiController]
    [Route("admanager")]
    public class AdManagerController : ControllerBase
    {        
        private readonly ILogger<AdManagerController> _logger;

        public AdManagerController(AdUserManager userManager, ILogger<AdManagerController> logger)
        {            
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult<string> Get()
        {
            return "welcome to ad management";
        }
    }
}
