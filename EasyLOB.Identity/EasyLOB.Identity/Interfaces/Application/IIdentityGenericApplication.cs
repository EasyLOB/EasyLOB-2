using EasyLOB.Application;
using EasyLOB.Data;

namespace EasyLOB.Identity
{
    public interface IIdentityGenericApplication<TEntity> : IGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}