using System.Collections.Generic;

namespace EasyLOB.Security
{
    public class AppProfile
    {
        #region Properties User

        public bool IsAdministrator { get; }

        public bool IsAuthenticated { get; }

        public List<string> Roles { get; }

        public string UserName { get; }

        #endregion Properties User

        #region Methods

        public AppProfile()
        {
            IsAdministrator = false;
            IsAuthenticated = false;
            Roles = new List<string>();
            UserName = "";
        }

        public AppProfile(IAuthenticationManager authenticationManager)
        {
            IsAdministrator = authenticationManager.IsAdministrator;
            IsAuthenticated = authenticationManager.IsAuthenticated;
            Roles = authenticationManager.Roles;
            UserName = authenticationManager.UserName;
        }

        #endregion Methods
    }
}