using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Identity.Data
{
    public partial class UserLoginDTO : ZDTOBase<UserLoginDTO, UserLogin>
    {
        #region Properties
               
        public virtual string LoginProvider { get; set; }
               
        public virtual string ProviderKey { get; set; }
               
        public virtual string UserId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId
    
        #endregion Associations FK

        #region Methods
        
        public UserLoginDTO()
        {
            LoginProvider = LibraryDefaults.Default_String;
            ProviderKey = LibraryDefaults.Default_String;
            UserId = LibraryDefaults.Default_String;
            UserLookupText = null;
            LookupText = null;
        }
        
        public UserLoginDTO(
            string loginProvider,
            string providerKey,
            string userId,
            string userLookupText = null
        )
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
            UserId = userId;
            UserLookupText = userLookupText;
            LookupText = null;
        }

        public UserLoginDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<UserLoginDTO, UserLogin> GetDataSelector()
        {
            return x => new UserLogin
            (
                x.LoginProvider,
                x.ProviderKey,
                x.UserId
            );
        }

        public override Func<UserLogin, UserLoginDTO> GetDTOSelector()
        {
            return x => new UserLoginDTO
            (
                x.LoginProvider,
                x.ProviderKey,
                x.UserId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                UserLogin userLogin = (UserLogin)data;
                UserLoginDTO dto = (new List<UserLogin> { userLogin })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.UserLookupText = userLogin.User == null ? null : userLogin.User.LookupText;
                dto.LookupText = userLogin.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<UserLoginDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
