using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfiguration
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "AuditTrailConfiguration",
            IsIdentity: true,
            Keys: new List<string> { "Id" },
            Lookup: "Domain",
            LINQOrderBy: "Domain",
            LINQWhere: "Id == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 100, false, false, "col-md-1", "Id"),
                new ZProfileProperty(true , true , 240, true , false, "col-md-4", "Domain"),
                new ZProfileProperty(true , true , 240, true , false, "col-md-4", "Entity"),
                new ZProfileProperty(true , true , 100, true , false, "col-md-2", "LogMode"), // !?!
                new ZProfileProperty(true , true , 240, true , false, "col-md-4", "LogOperations") // !?!
            }
        );

        #endregion Profile
    }
}
