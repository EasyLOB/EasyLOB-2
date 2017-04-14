using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaimDTO : ZDTOBase<UserClaimDTO, UserClaim>
    {
        #region Properties
               
        public virtual int Id { get; set; }
               
        public virtual string UserId { get; set; }
               
        public virtual string ClaimType { get; set; }
               
        public virtual string ClaimValue { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations FK

        #region Methods
        
        public UserClaimDTO()
        {
            Id = LibraryDefaults.Default_Int32;
            UserId = LibraryDefaults.Default_String;
            ClaimType = null;
            ClaimValue = null;
            UserLookupText = null;
            LookupText = null;
        }
        
        public UserClaimDTO(
            int id,
            string userId,
            string claimType = null,
            string claimValue = null,
            string userLookupText = null
        )
        {
            Id = id;
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
            UserLookupText = userLookupText;
            LookupText = null;
        }

        public UserClaimDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<UserClaimDTO, UserClaim> GetDataSelector()
        {
            return x => new UserClaim
            (
                x.Id,
                x.UserId,
                x.ClaimType,
                x.ClaimValue
            );
        }

        public override Func<UserClaim, UserClaimDTO> GetDTOSelector()
        {
            return x => new UserClaimDTO
            (
                x.Id,
                x.UserId,
                x.ClaimType,
                x.ClaimValue
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                UserClaim userClaim = (UserClaim)data;
                UserClaimDTO dto = (new List<UserClaim> { userClaim })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.UserLookupText = userClaim.User == null ? null : userClaim.User.LookupText;
                dto.LookupText = userClaim.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<UserClaimDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
