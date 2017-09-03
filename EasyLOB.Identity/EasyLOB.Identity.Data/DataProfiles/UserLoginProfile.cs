using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserLogin
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "UserLogin",
                IsIdentity: false,
                Keys: new string[] { "LoginProvider", "ProviderKey", "UserId" },
                Lookup: "ProviderKey",
                Associations: new string[]
                {
                    "User"
                },
                CollectionsDictionary: new Dictionary<string, bool> { },
                LINQOrderBy: "ProviderKey",
                LINQWhere: "LoginProvider == @0 && ProviderKey == @1 && UserId == @2"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "LoginProvider"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "ProviderKey"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "UserId"),
                new ZPropertyProfile(true , true , 100, false, false, "col-md-4", "UserLookupText")
            }
        };

        #endregion Profile
    }
}
