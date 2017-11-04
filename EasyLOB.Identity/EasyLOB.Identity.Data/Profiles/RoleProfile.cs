using EasyLOB.Data;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class Role
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Role",
            IsIdentity: false,
            Keys: new List<string> { "Id" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "Id == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool>
            {
                { "UserRoles", true }
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true , 200, false, false, "col-md-4", "Id"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name"),
                new ZProfileProperty(false, true , 200, false, true , "col-md-4", "Discriminator") // !?!
            }
        );

        #endregion Profile
    }
}
