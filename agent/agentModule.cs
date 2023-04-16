using agent.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace agent
{
    public class agentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Proportion>();
            containerRegistry.RegisterForNavigation<Proportion_Piechart>();
            containerRegistry.RegisterForNavigation<Proportion_Treemap>();

            containerRegistry.RegisterForNavigation<InitialAgent>();
            containerRegistry.RegisterForNavigation<InitialAgent_AgentSetTable>();

            containerRegistry.RegisterForNavigation<LearnAgent>();
            containerRegistry.RegisterForNavigation<LearnAgent_Messageconfig>();

        }
    }
}