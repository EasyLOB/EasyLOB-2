using System.Collections.Generic;

namespace EasyLOB.Data
{
    public interface IZProfile
    {
        #region Properties

        string Name { get; }

        bool IsIdentity { get; }

        List<string> Keys { get; }

        string Lookup { get; }

        string LINQOrderBy { get; }

        string LINQWhere { get; }

        //bool IsLog { get; }

        //bool IsSearch { get; }

        //int RecordsByLookup { get; }

        //int RecordsByPage { get; }

        //int RecordsBySearch { get; }

        List<string> Associations { get; }

        Dictionary<string, bool> Collections { get; }

        List<IZProfileProperty> Properties { get; set; }

        #endregion Properties

        #region Properties Helper Edit

        List<string> EditCollections { get; }

        List<string> EditHiddenCollections { get; }

        List<string> EditHiddenProperties { get; }

        List<string> EditReadOnlyProperties { get; }

        #endregion Properties Helper Edit

        #region Properties Helper Grid

        List<string> GridProperties { get; }

        List<string> GridSearchProperties { get; }

        #endregion Properties Helper Grid

        #region Methods Helper Edit

        string EditCSSFor(string propertyName);

        bool IsCollectionVisibleFor(string collectionName);

        #endregion Methods Helper Edit

        #region Methods Helper Grid

        bool IsGridVisibleFor(string propertyName);

        int GridWidthFor(string propertyName);

        #endregion Methods Helper Grid
    }
}
 