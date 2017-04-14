using EasyLOB.Data;
using System;

namespace EasyLOB.AuditTrail
{
    public interface IAuditTrailManager : IDisposable
    {
        #region Methods

        bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataBase entityBefore, IZDataBase entityAfter);

        bool IsAuditTrail(string logDomain, string logEntity, string logOperation);

        #endregion Methods
    }
}