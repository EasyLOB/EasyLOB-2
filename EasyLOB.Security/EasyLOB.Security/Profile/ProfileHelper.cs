using EasyLOB.Library.Mvc;
using System;

namespace EasyLOB.Security
{
    public static class ProfileHelper
    {
        #region Fields

        private static string SessionName = "EasyLOB.Profile";

        #endregion Fields

        #region Properties

        public static AppProfile Profile
        {
            get
            {
                AppProfile profile = (AppProfile)SessionHelper.Read(SessionName);

                return profile ?? new AppProfile();
            }
        }

        #endregion Properties

        #region Methods

        public static void Login(IAuthenticationManager authenticationManager)
        {
            AppProfile profile = (AppProfile)SessionHelper.Read(SessionName);
            if (profile == null || String.IsNullOrEmpty(profile.UserName))
            {
                profile = new AppProfile(authenticationManager);

                SessionHelper.Write(SessionName, profile);
            }
        }

        #endregion Methods
    }
}