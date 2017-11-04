using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRole
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "ActivityRole",
            IsIdentity: false,
            Keys: new List<string> { "ActivityId", "RoleName" },
            Lookup: "Operations",
            LINQOrderBy: "Operations",
            LINQWhere: "ActivityId == @0 && RoleName == @1",
            Associations: new List<string>
            {
                "Activity"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "ActivityId"), // !?!
                new ZProfileProperty(true , true , 100, false, false, "col-md-4", "ActivityLookupText"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "RoleName"), // !?!
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Operations")
            }
        );

        #endregion Profile
    }
}
