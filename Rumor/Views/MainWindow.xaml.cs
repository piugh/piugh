using agent;
using Network;
using DryIoc;
using Prism.Ioc;
using Prism.Regions;
using Rumor.ViewModels;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;

namespace Rumor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserControl view;
        private IRegionManager _regionManager;
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectFunc(object sender, SelectionChangedEventArgs e)
        {
            IRegion region = _regionManager.Regions["DetialOfItem"]; ;
            //一定记得要清除region
            //由于需要进行region覆盖，所以view注入选择injetction，不是discover（不能删除qaq）
            region.RemoveAll();
            region = _regionManager.Regions["ListOfItem"];
            region.RemoveAll();            
            region = _regionManager.Regions["MenuRegion"];
            region.RemoveAll();
            //按键选择逻辑
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            switch (tabItem)
            {
                case "个体管理":
                    view = new Rumor_Agent();                    
                    break;
                case "网络管理":
                    view = new Rumor_NetWork();
                    break;
                case "消息管理":
                    view = new Rumor_Knowlege();
                    break;
                case "计算实验管理":
                    //view = new Experiment.Views.ViewA();
                    break;
                default:
                    return;
            }
            region.Add(view);
        }
    }
}
