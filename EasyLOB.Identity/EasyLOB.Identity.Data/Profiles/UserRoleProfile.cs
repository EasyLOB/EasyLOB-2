using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserRole
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "UserRole",
            IsIdentity: false,
            Keys: new string[] { "UserId", "RoleId" },
            Lookup: "RoleId",
            LINQOrderBy: "RoleId",
            LINQWhere: "UserId == @0 && RoleId == @1",
            Associations: new string[]
            {
                "Role",
                "User"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "UserId"), // !?!
                new ZProfileProperty(true , true , 100, false, false, "col-md-4", "UserLookupText"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "RoleId"), // !?!
                new ZProfileProperty(true , true , 100, false, false, "col-md-4", "RoleLookupText")
            }
        );

        #endregion Profile
    }
}
