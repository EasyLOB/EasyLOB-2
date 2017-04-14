using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRoleDTO : ZDTOBase<ActivityRoleDTO, ActivityRole>
    {
        #region Properties
               
        public virtual string ActivityId { get; set; }
               
        public virtual string RoleName { get; set; }
               
        public virtual string Operations { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string ActivityLookupText { get; set; } // ActivityId
    
        #endregion Associations FK

        #region Methods
        
        public ActivityRoleDTO()
        {
            ActivityId = LibraryDefaults.Default_String;
            RoleName = LibraryDefaults.Default_String;
            Operations = null;
            ActivityLookupText = null;
            LookupText = null;
        }
        
        public ActivityRoleDTO(
            string activityId,
            string roleId,
            string operations = null,
            string activityLookupText = null
        )
        {
            ActivityId = activityId;
            RoleName = roleId;
            Operations = operations;
            ActivityLookupText = activityLookupText;
            LookupText = null;
        }

        public ActivityRoleDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<ActivityRoleDTO, ActivityRole> GetDataSelector()
        {
            return x => new ActivityRole
            (
                x.ActivityId,
                x.RoleName,
                x.Operations
            );
        }

        public override Func<ActivityRole, ActivityRoleDTO> GetDTOSelector()
        {
            return x => new ActivityRoleDTO
            (
                x.ActivityId,
                x.RoleName,
                x.Operations
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                ActivityRole activityRole = (ActivityRole)data;
                ActivityRoleDTO dto = (new List<ActivityRole> { activityRole })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.ActivityLookupText = activityRole.Activity == null ? null : activityRole.Activity.LookupText;
                dto.LookupText = activityRole.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<ActivityRoleDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
