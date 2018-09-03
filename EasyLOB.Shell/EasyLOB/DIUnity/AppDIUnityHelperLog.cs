using EasyLOB.Log;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupLog()
        {
            //_container.RegisterType(typeof(ILogManager), typeof(LogManagerMock), AppLifetimeManager);
            _container.RegisterType(typeof(ILogManager), typeof(LogManager), AppLifetimeManager);
        }
    }
}