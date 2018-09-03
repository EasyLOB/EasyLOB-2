using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupAuditTrail()
        {
            _container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManagerMock), AppLifetimeManager);
            //_container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManager), AppLifetimeManager);

            _container.RegisterType(typeof(IAuditTrailGenericApplication<>), typeof(AuditTrailGenericApplication<>), AppLifetimeManager);
            _container.RegisterType(typeof(IAuditTrailGenericApplicationDTO<,>), typeof(AuditTrailGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            _container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkEF), AppLifetimeManager);
            _container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //_container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkLINQ2DB), AppLifetimeManager);
            //_container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //_container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkNH), AppLifetimeManager);
            //_container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}