using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;
using System.Security.Principal;
using System.Threading;
using Unity;
using Unity.Injection;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupIdentity()
        {
            _container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManagerMock), AppLifetimeManager);
            //_container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManager), AppLifetimeManager);

            _container.RegisterType(typeof(IIdentityGenericApplication<>), typeof(IdentityGenericApplication<>), AppLifetimeManager);
            _container.RegisterType(typeof(IIdentityGenericApplicationDTO<,>), typeof(IdentityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            _container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkEF), AppLifetimeManager);
            _container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryEF<>), AppLifetimeManager);

            // NHibernate
            //_container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkNH), AppLifetimeManager);
            //_container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}