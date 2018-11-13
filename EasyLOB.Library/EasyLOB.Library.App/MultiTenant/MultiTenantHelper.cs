using EasyLOB.Library.AspNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasyLOB.Library.App
{
    public static class MultiTenantHelper
    {
        #region Fields

        private static string SessionName = "EasyLOB.MultiTenant";

        #endregion Fields

        #region Properties

        private static string _applicationDirectory;

        public static string ApplicationDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(_applicationDirectory))
                {
                    if (WebHelper.IsWeb)
                    {
                        _applicationDirectory = WebHelper.ApplicationDirectory;
                    }
                }

                return _applicationDirectory;
            }
        }

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
            get
            {
                string tenantName = WebHelper.WebSubDomain;

                return GetTenant(String.IsNullOrEmpty(tenantName) ? TenantName : tenantName);
            }
        }

        private static string _tenantName = "";

        public static string TenantName
        {
            get
            {
                if (String.IsNullOrEmpty(_tenantName))
                {
                    if (WebHelper.IsWeb)
                    {
                        _tenantName = WebHelper.WebSubDomain;
                    }
                }

                return _tenantName;
            }
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
                        string filePath = Path.Combine(MultiTenantHelper.WebDirectory(ConfigurationHelper.AppSettings<string>("Directory.Configuration")),
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

        public static void Setup(string tenantName, string applicationDirectory)
        {
            _tenantName = tenantName;
            _applicationDirectory = applicationDirectory;
        }

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

            if (IsMultiTenant)
            {
                if (Tenants.Count > 0)
                {
                    name = name.ToLower();
                    foreach (AppTenant t in Tenants)
                    {
                        if (name.StartsWith(t.Name.ToLower()))
                        //if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            appTenant = t;
                            break;
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

        public static string WebDirectory(string path)
        {
            string result = "";

            if (WebHelper.IsWeb)
            {
                result = WebHelper.WebDirectory(path);
            }
            else
            {
                result = Path.Combine(ApplicationDirectory, path.Trim('~', '/', '\\'));
            }

            return result;
        }

        #endregion Methods
    }
}