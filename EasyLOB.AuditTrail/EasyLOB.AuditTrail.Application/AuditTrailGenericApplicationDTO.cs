using EasyLOB.Application;
//using EasyLOB.AuditTrail;
using EasyLOB.Data;
//using EasyLOB.Log;
//using EasyLOB.Security;

namespace EasyLOB.AuditTrail.Application
{
    public class AuditTrailGenericApplicationDTO<TEntityDTO, TEntity>
        : GenericApplicationDTO<TEntityDTO, TEntity>, IAuditTrailGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public AuditTrailGenericApplicationDTO(IAuditTrailUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
        {
        }

        #endregion Methods
    }
}