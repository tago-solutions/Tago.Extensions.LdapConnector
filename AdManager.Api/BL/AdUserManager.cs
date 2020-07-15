using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tago.Ldap.AdUtils;

namespace AdManager.Api.BL
{

    public class DnRequest
    {
        public string Dn { get; set; }
    }

    public class AddGroupRequest : DnRequest
    {
    }

    public class RemoveGroupRequest : DnRequest
    {
    }

    public class UserNotFoundExcption : Exception
    {

    }

    public class AdUserService
    {


        private readonly AdUserManager userManager;

        public AdUserService(AdUserManager userManager)
        {
            this.userManager = userManager;
        }


        public AdUser GetUserInfo(string id)
        {
            return userManager.GetUser(id);
        }

        public string GetUserDn(string id)
        {
            return userManager.GetUserDn(id);
        }

        
        public bool CreateUser(CreateAdUser user)
        {
            userManager.CreateAdUser(user);
            return true;
        }

        
        public bool DeleteUser(string id)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return userManager.DeleteUser(user.Path);
            }
            else
            {
                throw new UserNotFoundExcption();
            }
        }

        
        public bool Enable(string id)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return userManager.EnableUser(user.Path);
            }
            else
            {
                throw new UserNotFoundExcption();
            }
        }

        
        public bool Disable(string id)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return userManager.DisableUser(user.Path);
            }
            else
            {
                throw new UserNotFoundExcption();
            }
        }

        public string[] GetGroups(string id)
        {
            return userManager.GetUserGroups(id);
        }

        public bool AddToGroup(string id, AddGroupRequest request)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return userManager.AddToGroup(user.Path, request.Dn);
            }
            else
            {
                throw new UserNotFoundExcption();
            }
        }


        
        public bool RemoveFromGroup(string id, AddGroupRequest request)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return userManager.RemoveFromGroup(user.Path, request.Dn);
            }
            else
            {
                throw new UserNotFoundExcption();
            }
        }
    }
}
