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
            containerRegistry.RegisterForNavigation<ExperimentItem_RumorDelivery>();

            containerRegistry.RegisterForNavigation<ExperimentResult>();
            containerRegistry.RegisterForNavigation<ExperimentResult_Overview>();
            containerRegistry.RegisterForNavigation<ExperimentResult_Inforesult>();


        }
    }
}