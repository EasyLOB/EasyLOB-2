using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaim
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
                        Name: "UserClaim",
                        IsIdentity: true,
                        Keys: new string[] { "Id" },
                        Lookup: "UserId",
                        Associations: new string[]
                        {
                            "User"
                        },
                        CollectionsDictionary: new Dictionary<string, bool> { },
                        LINQOrderBy: "UserId",
                        LINQWhere: "Id == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true , 100, false, false, "col-md-1", "Id"),
                        new ZPropertyProfile(false, false, 200, true , false, "col-md-4", "UserId"),
                        new ZPropertyProfile(true , true , 100, false, false, "col-md-4", "UserLookupText"),
                        new ZPropertyProfile(true , true , -10, true , false, "col-md-1", "ClaimType"),
                        new ZPropertyProfile(true , true , -10, true , false, "col-md-1", "ClaimValue")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
