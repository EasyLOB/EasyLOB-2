using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserRole
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "UserRole",
                IsIdentity: false,
                Keys: new string[] { "UserId", "RoleId" },
                Lookup: "RoleId",
                Associations: new string[]
                {
                    "Role",
                    "User"
                },
                CollectionsDictionary: new Dictionary<string, bool> { },
                LINQOrderBy: "RoleId",
                LINQWhere: "UserId == @0 && RoleId == @1"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "UserId"), // !?!
                new ZPropertyProfile(true , true , 100, false, false, "col-md-4", "UserLookupText"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "RoleId"), // !?!
                new ZPropertyProfile(true , true , 100, false, false, "col-md-4", "RoleLookupText")
            }
        };

        #endregion Profile
    }
}
