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
            containerRegistry.RegisterForNavigation<Message_Details>();

            containerRegistry.RegisterForNavigation<MessageQueu>();
            containerRegistry.RegisterForNavigation<MessageQueu_Queueinfo>();

            containerRegistry.RegisterForNavigation<Experience>();
            containerRegistry.RegisterForNavigation<Experience_Details>();

            containerRegistry.RegisterForNavigation<ExperienceQueu>();
            containerRegistry.RegisterForNavigation<ExperienceQueu_Queueinfo>();

        }
    }
}