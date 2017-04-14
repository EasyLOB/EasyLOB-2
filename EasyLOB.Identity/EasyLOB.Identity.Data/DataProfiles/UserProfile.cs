using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class User
    {
        #region Dictionaries

        public static IZDataProfile DataProfile
        {
            get
            {
                return new ZDataProfile
                {
                    Class = new ZClassProfile
                    (
                        Name: "User",
                        IsIdentity: false,
                        Keys: new string[] { "Id" },
                        Lookup: "UserName", // !?!
                        Associations: new string[] { },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "UserClaims", false }, // !?!
                            { "UserLogins", false }, // !?!
                            { "UserRoles", true }
                        },
                        LINQOrderBy: "UserName", // !?!
                        LINQWhere: "Id == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true , 240, false, false, "col-md-4", "Id"),
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "Email"),
                        new ZPropertyProfile(true , false, 100, false, false, "col-md-2", "EmailConfirmed"), // !?!
                        new ZPropertyProfile(false, false, 100, true , false, "col-md-1", "PasswordHash"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-1", "SecurityStamp"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-1", "PhoneNumber"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-2", "PhoneNumberConfirmed"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-2", "TwoFactorEnabled"), // !?!
                        new ZPropertyProfile(false, false, 200, false, false, "col-md-2", "LockoutEndDateUtc"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-2", "LockoutEnabled"), // !?!
                        new ZPropertyProfile(false, false, 100, false, false, "col-md-1", "AccessFailedCount"), // !?!
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "UserName") // !?!
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
