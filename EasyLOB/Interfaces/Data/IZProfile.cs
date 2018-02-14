using System.Collections.Generic;

namespace EasyLOB.Data
{
    public interface IZProfile
    {
        #region Properties

        string Name { get; set; }

        bool IsIdentity { get; set; }

        List<string> Keys { get; set; }

        string Lookup { get; set; }

        string LINQOrderBy { get; set; }

        string LINQWhere { get; set; }

        //bool IsLog { get; set; }

        //bool IsSearch { get; set; }

        //int RecordsByLookup { get; set; }

        //int RecordsByPage { get; set; }

        //int RecordsBySearch { get; set; }

        List<string> Associations { get; }

        Dictionary<string, bool> Collections { get; }

        List<IZProfileProperty> Properties { get; }

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

        #region Methods

        IZProfileProperty GetProfileProperty(string name);

        #endregion Methods

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
 