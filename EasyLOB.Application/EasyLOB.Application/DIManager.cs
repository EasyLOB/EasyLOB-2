using Microsoft.Practices.Unity;

namespace EasyLOB.Application
{
    public class DIManager : IDIManager
    {
        #region Properties

        private IUnityContainer Container { get; }

        #endregion

        #region Methods

        public DIManager(IUnityContainer container)
        {
            Container = container;
        }

        public object Resolve<T>()
        {
            return Container.Resolve<T>();
        }        

        #endregion
    }
}