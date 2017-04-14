using System.Collections.Generic;

namespace EasyLOB.Data
{
    public interface IZClassProfile
    {
        #region Properties

        string Name { get; }

        bool IsIdentity { get; }

        string[] Keys { get; }

        string Lookup { get; }

        string[] Associations { get; }

        /*
        string[] Collections { get; }

        bool[] IsVisibleCollections { get; }
         */

        Dictionary<string, bool> CollectionsDictionary { get; }

        string LINQOrderBy { get; }

        string LINQWhere { get; }

        int RecordsByLookup { get; }

        int RecordsByPage { get; }

        int RecordsBySearch { get; }

        #endregion Properties
    }
}