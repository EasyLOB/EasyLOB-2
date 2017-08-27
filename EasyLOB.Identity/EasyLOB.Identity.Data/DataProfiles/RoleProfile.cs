using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class Role
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
                        Name: "Role",
                        IsIdentity: false,
                        Keys: new string[] { "Id" },
                        Lookup: "Name",
                        Associations: new string[] { },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "UserRoles", true }
                        },
                        LINQOrderBy: "Name",
                        LINQWhere: "Id == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true , 200, false, false, "col-md-4", "Id"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Name"),
                        new ZPropertyProfile(false, true , 200, false, true , "col-md-4", "Discriminator") // !?!
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
