using System;
using System.ComponentModel;
using System.Configuration;

namespace EasyLOB.Library
{
    public static partial class ConfigurationHelper
    {
        #region Methods

        public static T AppSettings<T>(string name)
        {
            var appSetting = ConfigurationManager.AppSettings[name];
            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)(converter.ConvertFromInvariantString(appSetting ?? ""));
        }

        public static string ConnectionStrings(string connectionName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception(String.Format("ConnectionStrings[\"{0}\"] = \"?\"", connectionString));
            }

            return connectionString;
        }

        #endregion Methods
    }
}