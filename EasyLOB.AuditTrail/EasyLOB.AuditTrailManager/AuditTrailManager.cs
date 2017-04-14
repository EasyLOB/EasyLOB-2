using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.AuditTrail
{
    public class AuditTrailManager : IAuditTrailManager
    {
        #region Properties AuditTrailManager

        public IAuditTrailUnitOfWork UnitOfWork { get; }

        #endregion Properties AuditTrailManager

        #region Methods

        public AuditTrailManager(IAuditTrailUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual void Dispose()
        {
        }

        public bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataBase entityBefore, IZDataBase entityAfter)
        {
            if (IsAuditTrail(logDomain, logEntity, logOperation))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    //Formatting = Formatting.Indented
                    Formatting = Formatting.None,
                    MaxDepth = 1
                };

                object[] ids;
                IZDataProfile dataProfile;
                if (entityAfter != null)
                {
                    ids = entityAfter.GetId();
                    dataProfile = DataHelper.GetDataProfile(entityAfter.GetType());
                }
                else // entityBefore != null
                {
                    ids = entityBefore.GetId();
                    dataProfile = DataHelper.GetDataProfile(entityBefore.GetType());
                }
                // {"Id1":1,"Id2":2}
                string logId = "";
                int idIndex = 0;
                foreach (string idProperty in dataProfile.Class.Keys)
                {
                    logId += (String.IsNullOrEmpty(logId) ? "" : ",") + "\"" + idProperty + "\":" + JsonConvert.SerializeObject(ids[idIndex++], settings);
                }
                logId = "{" + logId + "}";

                AuditTrailLog auditTrailLog = new AuditTrailLog();
                auditTrailLog.LogDate = DateTime.Today;
                auditTrailLog.LogTime = DateTime.Now;
                auditTrailLog.LogUserName = logUserName;
                auditTrailLog.LogDomain = logDomain;
                auditTrailLog.LogEntity = logEntity;
                auditTrailLog.LogOperation = logOperation;
                auditTrailLog.LogId = logId;
                auditTrailLog.LogEntityBefore = entityBefore == null ? "" : JsonConvert.SerializeObject(entityBefore, settings);
                auditTrailLog.LogEntityAfter = entityAfter == null ? "" : JsonConvert.SerializeObject(entityAfter, settings);

                IGenericRepository<AuditTrailLog> repository = UnitOfWork.GetRepository<AuditTrailLog>();
                if (repository.Create(operationResult, auditTrailLog))
                {
                    UnitOfWork.Save(operationResult);
                }
            }

            return operationResult.Ok;
        }

        public bool IsAuditTrail(string logDomain, string logEntity, string logOperation)
        {
            bool result = false;

            if (AuditTrailHelper.IsAuditTrail)
            {
                IGenericRepository<AuditTrailConfiguration> repository = UnitOfWork.GetRepository<AuditTrailConfiguration>();

                IEnumerable<AuditTrailConfiguration> enumerable =
                    repository.Select(x => x.Domain == logDomain && x.Entity == logEntity && x.LogOperations.Contains(logOperation));

                AuditTrailConfiguration auditTrailConfiguration = enumerable.FirstOrDefault<AuditTrailConfiguration>();

                result = auditTrailConfiguration != null;
            }

            return result;
        }

        #endregion Methods
    }
}