using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EasyLOB.Data
{
    public interface IZDataProfile
    {
        #region Properties

        IZClassProfile Class { get; set; }

        List<IZPropertyProfile> Properties { get; set; }

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

        string EditWidthCSSFor(string propertyName);

        bool IsCollectionVisibleFor(string collectionName);

        #endregion Methods Helper Edit

        #region Methods Helper Grid

        bool IsGridVisibleFor(string propertyName);

        int GridWidthFor(string propertyName);

        #endregion Methods Helper Grid
    }
}