using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Resource.Views;

namespace Resource
{
    public class ResourceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BaseInfoView>();
        }
    }
}