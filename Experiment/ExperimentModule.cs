using agent.Views;
using Experiment.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Experiment
{
    public class ExperimentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ExperimentItem>();
            containerRegistry.RegisterForNavigation<ExperimentResult>();
        }
    }
}