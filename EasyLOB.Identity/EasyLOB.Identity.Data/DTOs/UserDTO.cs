﻿using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace EasyLOB.Identity.Data
{
    public partial class UserDTO : ZDTOBase<UserDTO, User>
    {
        #region Properties
               
        public virtual string Id { get; set; }
               
        public virtual string Email { get; set; }
               
        public virtual bool EmailConfirmed { get; set; }
               
        public virtual string PasswordHash { get; set; }
               
        public virtual string SecurityStamp { get; set; }
               
        public virtual string PhoneNumber { get; set; }
               
        public virtual bool PhoneNumberConfirmed { get; set; }
               
        public virtual bool TwoFactorEnabled { get; set; }
               
        public virtual DateTime? LockoutEndDateUtc { get; set; }
               
        public virtual bool LockoutEnabled { get; set; }
               
        public virtual int AccessFailedCount { get; set; }
               
        public virtual string UserName { get; set; }

        #endregion Properties

        #region Methods
        
        public UserDTO()
        {
            Id = LibraryDefaults.Default_String;
            EmailConfirmed = LibraryDefaults.Default_Boolean;
            PhoneNumberConfirmed = LibraryDefaults.Default_Boolean;
            TwoFactorEnabled = LibraryDefaults.Default_Boolean;
            LockoutEnabled = LibraryDefaults.Default_Boolean;
            AccessFailedCount = LibraryDefaults.Default_Int32;
            UserName = LibraryDefaults.Default_String;
            Email = null;
            PasswordHash = null;
            SecurityStamp = null;
            PhoneNumber = null;
            LockoutEndDateUtc = null;
            LookupText = null;
        }
        
        public UserDTO(
            string id,
            bool emailConfirmed,
            bool phoneNumberConfirmed,
            bool twoFactorEnabled,
            bool lockoutEnabled,
            int accessFailedCount,
            string userName,
            string email = null,
            string passwordHash = null,
            string securityStamp = null,
            string phoneNumber = null,
            DateTime? lockoutEndDateUtc = null
        )
        {
            Id = id;
            Email = email;
            EmailConfirmed = emailConfirmed;
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            TwoFactorEnabled = twoFactorEnabled;
            LockoutEndDateUtc = lockoutEndDateUtc;
            LockoutEnabled = lockoutEnabled;
            AccessFailedCount = accessFailedCount;
            UserName = userName;
            LookupText = null;
        }

        public UserDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<UserDTO, User> GetDataSelector()
        {
            return x => new User
            (
                x.Id,
                x.EmailConfirmed,
                x.PhoneNumberConfirmed,
                x.TwoFactorEnabled,
                x.LockoutEnabled,
                x.AccessFailedCount,
                x.UserName,
                x.Email,
                x.PasswordHash,
                x.SecurityStamp,
                x.PhoneNumber,
                x.LockoutEndDateUtc
            );
        }

        public override Func<User, UserDTO> GetDTOSelector()
        {
            return x => new UserDTO
            (
                x.Id,
                x.EmailConfirmed,
                x.PhoneNumberConfirmed,
                x.TwoFactorEnabled,
                x.LockoutEnabled,
                x.AccessFailedCount,
                x.UserName,
                x.Email,
                x.PasswordHash,
                x.SecurityStamp,
                x.PhoneNumber,
                x.LockoutEndDateUtc
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                User user = (User)data;
                UserDTO dto = (new List<User> { user })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = user.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<UserDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
