using Prism.Ioc;
using Prism.Modularity;
using Rumor.Views;
using System.Reflection;
using System.Windows;

namespace Rumor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // 应用程序启动时创建Shell
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
        //加载模块几种方法：
        //1. 配置app.config
        //2. 代码方式（我用这个！简单一点）
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Resource.ResourceModule>();
            moduleCatalog.AddModule<agent.agentModule>();
            moduleCatalog.AddModule<Network.NetworkModule>();
            moduleCatalog.AddModule<Knowledge.KnowledgeModule>();
            moduleCatalog.AddModule<Experiment.ExperimentModule>();
        }

    }
}
