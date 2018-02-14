namespace EasyLOB.Data
{
    public interface IZProfileProperty
    {
        #region Properties

        string Name { get; set; }

        bool IsGridVisible { get; set; }

        bool IsGridSearch { get; set; }

        int GridWidth { get; set; }

        bool IsEditVisible { get; set; }

        bool IsEditReadOnly { get; set; }

        string EditCSS { get; set; }

        #endregion Properties
    }
}