namespace EasyLOB.Data
{
    public interface IZProfileProperty
    {
        #region Properties

        string Name { get; }

        bool IsGridVisible { get; }

        bool IsGridSearch { get; }

        int GridWidth { get; }

        bool IsEditVisible { get; }

        bool IsEditReadOnly { get; }

        string EditCSS { get; }

        #endregion Properties
    }
}