using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class Activity
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "Activity",
                IsIdentity: false,
                Keys: new string[] { "Id" },
                Lookup: "Name",
                Associations: new string[] { },
                CollectionsDictionary: new Dictionary<string, bool>
                {
                    { "ActivityRoles", true }
                },
                LINQOrderBy: "Name",
                LINQWhere: "Id == @0"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true , 200, false, false, "col-md-4", "Id"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Name")
            }
        };

        #endregion Profile
    }
}
