using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaim
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "UserClaim",
            IsIdentity: true,
            Keys: new List<string> { "Id" },
            Lookup: "UserId",
            LINQOrderBy: "UserId",
            LINQWhere: "Id == @0",
            Associations: new List<string>
            {
                "User"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 100, false, false, "col-md-1", "Id"),
                new ZProfileProperty(false, false, 200, true , false, "col-md-4", "UserId"),
                new ZProfileProperty(true , true , 100, false, false, "col-md-4", "UserLookupText"),
                new ZProfileProperty(true , true , -10, true , false, "col-md-1", "ClaimType"),
                new ZProfileProperty(true , true , -10, true , false, "col-md-1", "ClaimValue")
            }
        );

        #endregion Profile
    }
}
