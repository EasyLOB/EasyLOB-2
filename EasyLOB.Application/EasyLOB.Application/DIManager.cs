using Microsoft.Practices.Unity;

namespace EasyLOB.Application
{
    public class DIManager : IDIManager
    {
        #region Properties

        IUnityContainer Container { get; }

        #endregion

        #region Methods

        public DIManager(IUnityContainer container)
        {
            Container = container;
        }

        public object Resolve<Interface>()
        {
            return Container.Resolve<Interface>();
        }        

        #endregion
    }
}