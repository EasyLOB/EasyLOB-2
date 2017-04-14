using EasyLOB.Application;
//using EasyLOB.AuditTrail;
using EasyLOB.Data;
//using EasyLOB.Log;
//using EasyLOB.Security;

namespace EasyLOB.Identity.Application
{
    public class IdentityGenericApplication<TEntity> : GenericApplication<TEntity>, IIdentityGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericApplication(IIdentityUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
        {
        }

        #endregion Methods
    }
}