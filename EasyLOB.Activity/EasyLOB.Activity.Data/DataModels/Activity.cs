using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Activity.Data
{
    public partial class Activity : ZDataBase
    {
        #region Properties

        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<ActivityRole> ActivityRoles { get; }

        #endregion Collections (PK)

        #region Methods

        public Activity()
        {
            Id = LibraryDefaults.Default_String;
            Name = LibraryDefaults.Default_String;

            ActivityRoles = new List<ActivityRole>();

            OnConstructor();

            // !?!
            Id = Guid.NewGuid().ToString();
        }

        public Activity(string id)
            : this()
        {
            if (!String.IsNullOrEmpty(id)) // !?!
            {
                Id = id;
            }
        }

        public Activity(
            string id,
            string name
        )
            : this()
        {
            if (!String.IsNullOrEmpty(id)) // !?!
            {
                Id = id;
            }
            Name = name;
        }

        public override object[] GetId()
        {
            return new object[] { Id };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                Id = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}