using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail
{
    public interface IAuditTrailGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}