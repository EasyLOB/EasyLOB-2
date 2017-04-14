using EasyLOB.Application;
//using EasyLOB.AuditTrail;
using EasyLOB.Data;
//using EasyLOB.Log;
//using EasyLOB.Security;

namespace EasyLOB.AuditTrail.Application
{
    public class AuditTrailGenericApplication<TEntity>
        : GenericApplication<TEntity>, IAuditTrailGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public AuditTrailGenericApplication(IAuditTrailUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
        {
        }

        #endregion Methods
    }
}
