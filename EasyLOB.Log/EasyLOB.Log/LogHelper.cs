using EasyLOB.Library;

namespace EasyLOB.Log
{
    public static partial class LogHelper
    {
        #region Properties

        public static bool IsLog
        {
            get
            {
                return ConfigurationHelper.AppSettings<bool>("EasyLOB.Log");
            }
        }

        #endregion Properties
    }
}