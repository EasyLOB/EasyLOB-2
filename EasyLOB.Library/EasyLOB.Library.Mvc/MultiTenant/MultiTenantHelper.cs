using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EasyLOB.Library.Mvc
{
    public static class MultiTenantHelper
    {
        #region Fields

        private static string SessionName = "EasyLOB.MultiTenant";

        #endregion Fields

        #region Properties

        public static bool HasTenants
        {
            get { return IsMultiTenant && Tenants != null ? true : false; }
        }

        public static bool IsMultiTenant
        {
            get { return ConfigurationHelper.AppSettings<bool>("EasyLOB.MultiTenant"); }
        }

        public static AppTenant Tenant
        {
            get { return GetTenant(MvcHelper.WebSubDomain); }
        }

        public static List<AppTenant> Tenants
        {
            get
            {
                List<AppTenant> tenants = (List<AppTenant>)SessionHelper.Read(SessionName);
                if (tenants == null || tenants.Count == 0)
                {
                    try
                    {
                        string filePath = Path.Combine(MvcHelper.WebDirectory(ConfigurationHelper.AppSettings<string>("Directory.Configuration")),
                            "JSON/MultiTenant.json");
                        string json = File.ReadAllText(filePath);
                        tenants = JsonConvert.DeserializeObject<List<AppTenant>>(json);
                    }
                    catch { }
                    tenants = tenants ?? new List<AppTenant>();

                    SessionHelper.Write(SessionName, tenants);
                }

                return tenants;
            }
        }

        #endregion Properties

        #region Methods

        public static string GetConnectionName(string defaultConnectionName)
        {
            string result = defaultConnectionName;

            if (Tenant != null)
            {
                foreach (AppTenantConnection appTenantConnection in Tenant.Connections)
                {
                    if (appTenantConnection.Name == defaultConnectionName)
                    {
                        result = appTenantConnection.ConnectionName;
                        break;
                    }
                }
            }

            return result;
        }

        public static string GetConnectionString(string defaultConnectionName)
        {
            return ConfigurationHelper.ConnectionStrings(GetConnectionName(defaultConnectionName));
        }

        public static AppTenant GetTenant(string name)
        {
            AppTenant appTenant = null;

            if (IsMultiTenant && MvcHelper.IsWeb)
            {
                if (IsMultiTenant)
                {
                    if (Tenants.Count > 0)
                    {
                        foreach (AppTenant t in Tenants)
                        {
                            if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                            {
                                appTenant = t;
                                break;
                            }
                        }
                    }
                }
            }

            if (appTenant == null && Tenants.Count > 0)
            {
                appTenant = Tenants[0];
            }

            appTenant = appTenant ?? new AppTenant();

            return appTenant;
        }

        #endregion Methods
    }
}