using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class User
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "User",
            IsIdentity: false,
            Keys: new List<string> { "Id" },
            Lookup: "UserName", // !?!
            LINQOrderBy: "UserName", // !?!
            LINQWhere: "Id == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool>
            {
                { "UserClaims", false }, // !?!
                { "UserLogins", false }, // !?!
                { "UserRoles", true }
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 200, false, false, "col-md-4", "Id"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Email"),
                new ZProfileProperty(true , false, 100, false, false, "col-md-2", "EmailConfirmed"), // !?!
                new ZProfileProperty(false, false, 100, true , false, "col-md-1", "PasswordHash"), // !?!
                new ZProfileProperty(false, false, 100, false, false, "col-md-1", "SecurityStamp"), // !?!
                new ZProfileProperty(false, false, 100, false, false, "col-md-1", "PhoneNumber"), // !?!
                new ZProfileProperty(false, false, 100, false, false, "col-md-2", "PhoneNumberConfirmed"), // !?!
                new ZProfileProperty(false, false, 100, false, false, "col-md-2", "TwoFactorEnabled"), // !?!
                new ZProfileProperty(true , false, 200, true , false, "col-md-2", "LockoutEndDateUtc"), // !?!
                new ZProfileProperty(true , false, 100, true , false, "col-md-2", "LockoutEnabled"), // !?!
                new ZProfileProperty(false, false, 100, false, false, "col-md-1", "AccessFailedCount"), // !?!
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "UserName") // !?!
            }
        );

        #endregion Profile
    }
}
