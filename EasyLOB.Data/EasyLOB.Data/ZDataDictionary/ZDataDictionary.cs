using System.Collections.ObjectModel;

// DataDictionary : List<DataProfile>
//     DataProfile
//         ClassProfile
//         ClassProfileCollection : List<PropertyProfile>
//             PropertyProfile

namespace EasyLOB.Data
{
    public class ZDataDictionary : KeyedCollection<string, ZDataProfile>
    {
        protected override string GetKeyForItem(ZDataProfile item)
        {
            return item.Class.Name;
        }
    }
}