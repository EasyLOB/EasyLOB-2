namespace EasyLOB.Data
{
    public interface IZPropertyProfile
    {
        #region Properties

        string Name { get; }

        bool IsGridVisible { get; }

        bool IsGridSearch { get; }

        int GridWidth { get; }

        bool IsEditVisible { get; }

        bool IsEditReadOnly { get; }

        string EditWidthCSS { get; }

        #endregion Properties
    }
}