
// DependencyResolver.Current.GetService -> DIHelper.GetService

namespace EasyLOB
{
    public static class DIHelper
    {
        #region Properties

        private static IDIManager _diManager;

        #endregion

        #region Methods

        public static void Setup(IDIManager diManager)
        {
            _diManager = diManager;
        }

        public static T GetService<T>()
        {
            return _diManager.GetService<T>();
        }

        #endregion
    }
}