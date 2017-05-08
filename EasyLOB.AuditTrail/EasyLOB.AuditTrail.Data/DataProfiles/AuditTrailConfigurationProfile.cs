using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfiguration
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
                        Name: "AuditTrailConfiguration",
                        IsIdentity: true,
                        Keys: new string[] { "Id" },
                        Lookup: "Domain",
                        Associations: new string[] { },
                        CollectionsDictionary: new Dictionary<string, bool> { },
                        LINQOrderBy: "Domain",
                        LINQWhere: "Id == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true , 100, false, false, "col-md-1", "Id"),
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "Domain"),
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "Entity"),
                        new ZPropertyProfile(true , true , 100, true , false, "col-md-2", "LogMode"), // !?!
                        new ZPropertyProfile(true , true , 240, true , false, "col-md-4", "LogOperations") // !?!
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
