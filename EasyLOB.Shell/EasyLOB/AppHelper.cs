using Newtonsoft.Json;
using Unity;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static JsonSerializerSettings _jsonSettings;

        public static JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.None,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                }

                return _jsonSettings;
            }
        }

        #endregion Properties    

        #region Methods

        public static void Setup()
        {
            // Unity
            // EasyLOB.DIService
            AppDIUnityHelper.Setup(new UnityContainer());
        }
        #endregion Methods
    }
}