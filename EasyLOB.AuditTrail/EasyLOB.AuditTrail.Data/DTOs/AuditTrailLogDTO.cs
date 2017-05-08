using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLogDTO : ZDTOBase<AuditTrailLogDTO, AuditTrailLog>
    {
        #region Properties
               
        public virtual int Id { get; set; }
               
        public virtual DateTime? LogDate { get; set; }
               
        public virtual DateTime? LogTime { get; set; }
               
        public virtual string LogUserName { get; set; }
               
        public virtual string LogDomain { get; set; }
               
        public virtual string LogEntity { get; set; }
               
        public virtual string LogOperation { get; set; }
               
        public virtual string LogId { get; set; }
               
        public virtual string LogEntityBefore { get; set; }
               
        public virtual string LogEntityAfter { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailLogDTO()
        {
            Id = LibraryDefaults.Default_Int32;
            LogDate = null;
            LogTime = null;
            LogUserName = null;
            LogDomain = null;
            LogEntity = null;
            LogOperation = null;
            LogId = null;
            LogEntityBefore = null;
            LogEntityAfter = null;
            LookupText = null;
        }
        
        public AuditTrailLogDTO(
            int id,
            DateTime? logDate = null,
            DateTime? logTime = null,
            string logUserName = null,
            string logDomain = null,
            string logEntity = null,
            string logOperation = null,
            string logId = null,
            string logEntityBefore = null,
            string logEntityAfter = null
        )
        {
            Id = id;
            LogDate = logDate;
            LogTime = logTime;
            LogUserName = logUserName;
            LogDomain = logDomain;
            LogEntity = logEntity;
            LogOperation = logOperation;
            LogId = logId;
            LogEntityBefore = logEntityBefore;
            LogEntityAfter = logEntityAfter;
            LookupText = null;
        }

        public AuditTrailLogDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<AuditTrailLogDTO, AuditTrailLog> GetDataSelector()
        {
            return x => new AuditTrailLog
            (
                x.Id,
                x.LogDate,
                x.LogTime,
                x.LogUserName,
                x.LogDomain,
                x.LogEntity,
                x.LogOperation,
                x.LogId,
                x.LogEntityBefore,
                x.LogEntityAfter
            );
        }

        public override Func<AuditTrailLog, AuditTrailLogDTO> GetDTOSelector()
        {
            return x => new AuditTrailLogDTO
            (
                x.Id,
                x.LogDate,
                x.LogTime,
                x.LogUserName,
                x.LogDomain,
                x.LogEntity,
                x.LogOperation,
                x.LogId,
                x.LogEntityBefore,
                x.LogEntityAfter
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                AuditTrailLog auditTrailLog = (AuditTrailLog)data;
                AuditTrailLogDTO dto = (new List<AuditTrailLog> { auditTrailLog })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = auditTrailLog.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<AuditTrailLogDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
