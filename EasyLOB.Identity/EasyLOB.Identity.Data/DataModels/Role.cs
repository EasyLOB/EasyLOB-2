using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Identity.Data
{
    public partial class Role : ZDataBase
    {
        #region Properties

        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Discriminator { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<UserRole> UserRoles { get; }

        #endregion Collections (PK)

        #region Methods

        public Role()
        {
            Id = LibraryDefaults.Default_String;
            Name = LibraryDefaults.Default_String;
            Discriminator = LibraryDefaults.Default_String;

            UserRoles = new List<UserRole>();

            OnConstructor();
        }

        public Role(string id)
            : this()
        {
            Id = id;
        }

        public Role(
            string id,
            string name,
            string discriminator
        )
            : this()
        {
            Id = id;
            Name = name;
            Discriminator = discriminator;
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