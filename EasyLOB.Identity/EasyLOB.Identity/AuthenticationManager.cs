using EasyLOB.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace EasyLOB.Identity
{
    public partial class AuthenticationManager : IAuthenticationManager
    {
        #region Properties

        public bool IsAdministrator
        {
            get
            {
                try
                {
                    bool result = false;
                    string userName = UserName.ToLower();

                    result = "|administrator|administrador|".Contains("|" + userName + "|");

                    //result = result || IsInRole("administrator") || IsInRole("administrador");
                    // The role names are case sensitive in AuthorizeAttribute and User.IsInRole
                    // The role names are case insensitive in UserManager.IsInRole
                    if (!result)
                    {
                        foreach (string roleName in Roles)
                        {
                            result = result || "|administrator|administrador|".Contains("|" + roleName.ToLower() + "|");
                            if (result)
                            {
                                break;
                            }
                        }
                    }

                    return result;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public List<string> Roles
        {
            get
            {
                return ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
            }
        }

        public string UserName
        {
            get
            {
                string userName = "";

                try
                {
                    userName = HttpContext.Current.User.Identity.GetUserName();
                }
                catch { }

                return userName;
            }
        }

        #endregion Properties

        #region Methods

        public bool IsInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}