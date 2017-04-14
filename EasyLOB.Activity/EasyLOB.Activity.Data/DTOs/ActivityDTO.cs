using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityDTO : ZDTOBase<ActivityDTO, Activity>
    {
        #region Properties
               
        public virtual string Id { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public ActivityDTO()
        {
            Id = LibraryDefaults.Default_String;
            Name = LibraryDefaults.Default_String;
            LookupText = null;
        }
        
        public ActivityDTO(
            string id,
            string name
        )
        {
            Id = id;
            Name = name;
            LookupText = null;
        }

        public ActivityDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<ActivityDTO, Activity> GetDataSelector()
        {
            return x => new Activity
            (
                x.Id,
                x.Name
            );
        }

        public override Func<Activity, ActivityDTO> GetDTOSelector()
        {
            return x => new ActivityDTO
            (
                x.Id,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Activity activity = (Activity)data;
                ActivityDTO dto = (new List<Activity> { activity })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = activity.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<ActivityDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
