using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Library.Web;
using EasyLOB.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Library.App
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

        public static void Login(IAuthenticationManager authenticationManager, IAuditTrailUnitOfWork auditTrailunitOfWork)
        {
            AppProfile profile = (AppProfile)SessionHelper.Read(SessionName);
            if (profile == null || String.IsNullOrEmpty(profile.UserName))
            {
                // User

                profile = new AppProfile(authenticationManager);

                // AuditTrail

                List<AuditTrailConfiguration> auditTrailConfigurations = (List<AuditTrailConfiguration>)auditTrailunitOfWork
                    .GetQuery<AuditTrailConfiguration>()
                    .OrderBy(x => x.Domain)
                    .ThenBy(x => x.Entity)
                    .ToList();
                foreach (AuditTrailConfiguration auditTrailConfiguration in auditTrailConfigurations)
                {
                    AppProfileAuditTrail auditTrail = new AppProfileAuditTrail();
                    auditTrail.Domain = auditTrailConfiguration.Domain;
                    auditTrail.Entity = auditTrailConfiguration.Entity;
                    auditTrail.LogMode = auditTrailConfiguration.LogMode;
                    auditTrail.LogOperations = auditTrailConfiguration.LogOperations;
                }

                SessionHelper.Write(SessionName, profile);
            }
        }

        #endregion Methods
    }
}