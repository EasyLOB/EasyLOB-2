using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfiguration : ZDataBase
    {        
        #region Properties
        
        public virtual int Id { get; set; }
        
        public virtual string Domain { get; set; }
        
        public virtual string Entity { get; set; }

        public virtual string LogMode { get; set; }

        public virtual string LogOperations { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailConfiguration()
        {            
            Id = LibraryDefaults.Default_Int32;
            Domain = LibraryDefaults.Default_String;
            Entity = LibraryDefaults.Default_String;
            LogMode = LibraryDefaults.Default_String;
            LogOperations = null;

            OnConstructor();
        }

        public AuditTrailConfiguration(int id)
            : this()
        {            
            Id = id;
        }

        public AuditTrailConfiguration(
            int id,
            string domain,
            string entity,
            string logMode,
            string logOperations = null
        )
            : this()
        {
            Id = id;
            Domain = domain;
            Entity = entity;
            LogMode = logMode;
            LogOperations = logOperations;
        }

        public override object[] GetId()
        {
            return new object[] { Id };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                Id = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
