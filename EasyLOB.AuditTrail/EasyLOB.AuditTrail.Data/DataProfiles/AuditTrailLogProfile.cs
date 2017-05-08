using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLog
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
                        Name: "AuditTrailLog",
                        IsIdentity: true,
                        Keys: new string[] { "Id" },
                        Lookup: "LogUserName",
                        Associations: new string[] { },
                        CollectionsDictionary: new Dictionary<string, bool> { },
                        LINQOrderBy: "LogUserName",
                        LINQWhere: "Id == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true , 100, false, false, "col-md-1", "Id"),
                        new ZPropertyProfile(true , false, 200, true , false, "col-md-2", "LogDate"),
                        new ZPropertyProfile(true , false, 200, true , false, "col-md-2", "LogTime"),
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "LogUserName"), // !?!
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "LogDomain"), // !?!
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "LogEntity"), // !?!
                        new ZPropertyProfile(true , true , 100, true , false, "col-md-2", "LogOperation"), // !?!
                        new ZPropertyProfile(false, true , 240, true , false, "col-md-4", "LogId"),
                        new ZPropertyProfile(false, true , 240, true , false, "col-md-8", "LogEntityBefore"), // !?!
                        new ZPropertyProfile(false, true , 240, true , false, "col-md-8", "LogEntityAfter") // !?!
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
