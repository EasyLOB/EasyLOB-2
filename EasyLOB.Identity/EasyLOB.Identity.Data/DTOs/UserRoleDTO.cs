using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Identity.Data
{
    public partial class UserRoleDTO : ZDTOBase<UserRoleDTO, UserRole>
    {
        #region Properties
               
        public virtual string UserId { get; set; }
               
        public virtual string RoleId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RoleLookupText { get; set; } // RoleId

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations FK

        #region Methods
        
        public UserRoleDTO()
        {
            UserId = LibraryDefaults.Default_String;
            RoleId = LibraryDefaults.Default_String;
            RoleLookupText = null;
            UserLookupText = null;
            LookupText = null;
        }
        
        public UserRoleDTO(
            string userId,
            string roleId,
            string roleLookupText = null,
            string userLookupText = null
        )
        {
            UserId = userId;
            RoleId = roleId;
            RoleLookupText = roleLookupText;
            UserLookupText = userLookupText;
            LookupText = null;
        }

        public UserRoleDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<UserRoleDTO, UserRole> GetDataSelector()
        {
            return x => new UserRole
            (
                x.UserId,
                x.RoleId
            );
        }

        public override Func<UserRole, UserRoleDTO> GetDTOSelector()
        {
            return x => new UserRoleDTO
            (
                x.UserId,
                x.RoleId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                UserRole userRole = (UserRole)data;
                UserRoleDTO dto = (new List<UserRole> { userRole })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.RoleLookupText = userRole.Role == null ? null : userRole.Role.LookupText;
                dto.UserLookupText = userRole.User == null ? null : userRole.User.LookupText;
                dto.LookupText = userRole.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<UserRoleDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
