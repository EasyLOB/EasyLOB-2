using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserLogin
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "UserLogin",
            IsIdentity: false,
            Keys: new List<string> { "LoginProvider", "ProviderKey", "UserId" },
            Lookup: "ProviderKey",
            LINQOrderBy: "ProviderKey",
            LINQWhere: "LoginProvider == @0 && ProviderKey == @1 && UserId == @2",
            Associations: new List<string>
            {
                "User"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "LoginProvider"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "ProviderKey"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "UserId"),
                new ZProfileProperty(true , true , 100, false, false, "col-md-4", "UserLookupText")
            }
        );

        #endregion Profile
    }
}
