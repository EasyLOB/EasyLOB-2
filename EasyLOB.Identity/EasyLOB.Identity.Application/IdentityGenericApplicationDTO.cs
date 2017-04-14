using EasyLOB.Application;
//using EasyLOB.AuditTrail;
using EasyLOB.Data;
//using EasyLOB.Log;
//using EasyLOB.Security;

namespace EasyLOB.Identity.Application
{
    public class IdentityGenericApplicationDTO<TEntityDTO, TEntity> : GenericApplicationDTO<TEntityDTO, TEntity>, IIdentityGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericApplicationDTO(IIdentityUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
        {
        }

        #endregion Methods
    }
}