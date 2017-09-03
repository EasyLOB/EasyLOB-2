using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRole
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "ActivityRole",
                IsIdentity: false,
                Keys: new string[] { "ActivityId", "RoleName" },
                Lookup: "Operations",
                Associations: new string[]
                {
                    "Activity"
                },
                CollectionsDictionary: new Dictionary<string, bool> { },
                LINQOrderBy: "Operations",
                LINQWhere: "ActivityId == @0 && RoleName == @1"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "ActivityId"), // !?!
                new ZPropertyProfile(true , true , 100, false, false, "col-md-4", "ActivityLookupText"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "RoleName"), // !?!
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Operations")
            }
        };

        #endregion Profile
    }
}
