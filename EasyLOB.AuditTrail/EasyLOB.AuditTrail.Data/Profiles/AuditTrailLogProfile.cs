using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLog
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "AuditTrailLog",
            IsIdentity: true,
            Keys: new List<string> { "Id" },
            Lookup: "LogUserName",
            LINQOrderBy: "LogUserName",
            LINQWhere: "Id == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 100, false, false, "col-md-1", "Id"),
                new ZProfileProperty(true , false, 100, true , false, "col-md-2", "LogDate"), // !?!
                new ZProfileProperty(true , false, 100, true , false, "col-md-2", "LogTime"), // !?!
                new ZProfileProperty(true , true , 100, true , false, "col-md-4", "LogUserName"), // !?!
                new ZProfileProperty(true , true , 100, true , false, "col-md-4", "LogDomain"), // !?!
                new ZProfileProperty(true , true , 100, true , false, "col-md-4", "LogEntity"), // !?!
                new ZProfileProperty(true , true ,  50, true , false, "col-md-2", "LogOperation"), // !?!
                new ZProfileProperty(false, true , 100, true , false, "col-md-4", "LogId"), // !?!
                new ZProfileProperty(false, true , 100, true , false, "col-md-8", "LogEntityBefore"), // !?!
                new ZProfileProperty(false, true , 100, true , false, "col-md-8", "LogEntityAfter") // !?!
            }
        );

        #endregion Profile
    }
}
