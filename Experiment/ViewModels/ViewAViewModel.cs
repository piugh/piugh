using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Experiment.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        #region 视图注入
        private UserControl view;
        private readonly IRegionManager _regionManager;
        #endregion

        #region 方案选择命令
        public DelegateCommand<string> Manage { get; set; }
        #endregion

        #region 方案选择操作
        private void SelectionManage(string i)
        {
            IRegion region = _regionManager.Regions["ListOfItem"];
            region.RemoveAll();
            switch (i)
            {
                case "0":
                    view = new Experiment.Views.ExperimentManage();
                    region.Add(view);
                    break;
                case "1":
                    view = new Experiment.Views.ExperimentResult();
                    region.Add(view);
                    break;
                default:
                    return;
            }

        }
        private bool CanExecute()
        {
            return true;
        }
        #endregion

        #region Main
        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            //执行Excute操作：每次MenuTxt变化后都要执行操作
            Manage = new DelegateCommand<string>(SelectionManage);
        }
        #endregion
    }
}
