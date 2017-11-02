using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class Activity
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Activity",
            IsIdentity: false,
            Keys: new string[] { "Id" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "Id == @0",
            Associations: new string[] { },
            Collections: new Dictionary<string, bool>
            {
                { "ActivityRoles", true }
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 200, false, false, "col-md-4", "Id"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name")
            }
        );

        #endregion Profile
    }
}
