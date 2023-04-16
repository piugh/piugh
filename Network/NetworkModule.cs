using Network.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Network
{
    public class NetworkModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NetConfig>();
            containerRegistry.RegisterForNavigation<NetConfig_Modelconfig>();

            containerRegistry.RegisterForNavigation<NetParameter>();
            containerRegistry.RegisterForNavigation<NetParameter_Paraconfig>();

            containerRegistry.RegisterForNavigation<NetResult>();
            containerRegistry.RegisterForNavigation<NetResult_Resultinfo>();

            containerRegistry.RegisterForNavigation<NetStructure>();
            containerRegistry.RegisterForNavigation<NetStructure_Pararefer>();

        }
    }
}