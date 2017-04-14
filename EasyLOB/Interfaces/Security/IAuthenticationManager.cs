 using System;
using System.Collections.Generic;

namespace EasyLOB.Security
{
    public interface IAuthenticationManager : IDisposable
    {
        #region Properties

        bool IsAdministrator { get; }

        bool IsAuthenticated { get; }

        List<string> Roles { get; }

        string UserName { get; }

        #endregion Properties

        #region Methods

        bool IsInRole(string role);

        #endregion Methods
    }
}