using Knowledge.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Knowledge
{
    public class KnowledgeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Message>();
            containerRegistry.RegisterForNavigation<MessageQueu>();
            containerRegistry.RegisterForNavigation<Experience>();
            containerRegistry.RegisterForNavigation<ExperienceQueu>();
        }
    }
}