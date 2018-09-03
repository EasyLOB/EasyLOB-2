using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupActivity()
        {
            _container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManagerMock), AppLifetimeManager);
            //_container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManager), AppLifetimeManager);

            _container.RegisterType(typeof(IActivityGenericApplication<>), typeof(ActivityGenericApplication<>), AppLifetimeManager);
            _container.RegisterType(typeof(IActivityGenericApplicationDTO<,>), typeof(ActivityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            _container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkEF), AppLifetimeManager);
            _container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //_container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkLINQ2DB), AppLifetimeManager);
            //_container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //_container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkNH), AppLifetimeManager);
            //_container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}