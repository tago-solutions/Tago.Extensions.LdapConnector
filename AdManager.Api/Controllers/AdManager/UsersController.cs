using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdManager.Api.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tago.Ldap;
using Tago.Ldap.AdUtils;

namespace AdManager.Api.Controllers
{
    [ApiController]
    [Route("admanager/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AdUserService userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AdUserService userManager, ILogger<UsersController> logger)
        {
            this.userManager = userManager;
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult<string> Get()
        {
            return "welcome to ad user management";
        }

        [HttpGet("{id}")]
        public ActionResult<AdUser> Get(string id)
        {
            return userManager.GetUserInfo(id);
        }

        [HttpPost]
        public ActionResult<bool> CreateUser(CreateAdUser user)
        {
            userManager.CreateUser(user);
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteUser(string id)
        {
            return userManager.DeleteUser(id);
        }

        [HttpPut("{id}/enable")]
        public ActionResult<bool> Enable(string id)
        {
            return userManager.Enable(id);
        }

        [HttpPut("{id}/disable")]
        public ActionResult<bool> Disable(string id)
        {
            return userManager.Disable(id);
        }



        [HttpGet("{id}/groups")]
        public ActionResult<string[]> GetGroups(string id)
        {
            return userManager.GetGroups(id);
        }        


        [HttpPost("{id}/groups")]
        public ActionResult<bool> AddToGroup(string id, AddGroupRequest request)
        {
            return userManager.AddToGroup(id, request);
        }


        [HttpDelete("{id}/groups")]
        public ActionResult<bool> RemoveFromGroup(string id, AddGroupRequest request)
        {
            return userManager.RemoveFromGroup(id, request);            
        }

    }
}


