using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Mail;
using Unity;
using Unity.Injection;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupExtensions()
        {
            //_container.RegisterType(typeof(IEdmManager), typeof(EdmManagerMock), AppLifetimeManager);
            _container.RegisterType(typeof(IEdmManager), typeof(EdmManagerFileSystem), AppLifetimeManager, new InjectionConstructor());
            //_container.RegisterType(typeof(IEdmManager), typeof(EdmFtpSystem), AppLifetimeManager, new InjectionConstructor());

            //_container.RegisterType(typeof(IIniManager), typeof(IniManagerMock), AppLifetimeManager);
            //_container.RegisterType(typeof(IIniManager), typeof(IniManager), AppLifetimeManager, new InjectionConstructor());

            //_container.RegisterType(typeof(IMailManager), typeof(MailManagerMock), AppLifetimeManager);
            _container.RegisterType(typeof(IMailManager), typeof(MailManager), AppLifetimeManager, new InjectionConstructor());
        }
    }
}