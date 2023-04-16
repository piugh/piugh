using Data;
using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Experiment.ViewModels
{
    public class ExperimentResultViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        private Domain.Entities.ExperimentResult _selectedItem;
        public Domain.Entities.ExperimentResult SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
        #endregion

        #region 显示信息
        private readonly IRegionManager _regionManager;
        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set
            {
                SetProperty(ref _tabIndex, value);
                //基本信息
                if (value == 0)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "BaseInfoView", parameter);
                }
                //结果总览
                if (value == 1)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "ExperimentResult_Overview", parameter);
                }
                //消息结果
                if (value == 2)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "ExperimentResult_Inforesult", parameter);
                }
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            List<SpreadInfo> temp = SelectedItem.SpreadInfos.ToList();
            SelectedItem.SpreadInfos.Clear();
            temp.OrderBy(i => i.Step).ToList();
            int id = 1;
            foreach (SpreadInfo spreadInfo in temp)
            {
                spreadInfo.Send.id = id;
                spreadInfo.Receive.id = id + 1;
                SelectedItem.SpreadInfos.Add(new SpreadInfo()
                {
                    Guid = spreadInfo.Guid,
                    Send = spreadInfo.Send,
                    Receive = spreadInfo.Receive,
                    Step = spreadInfo.Step,
                    RumorString = spreadInfo.RumorString,
                    MeanString = DataConvert.StringToRumor(spreadInfo.RumorString).MeanString
                });
                id++;
            }
            TabIndex = 0;
        }
        #endregion

        #region Main
        public ExperimentResultViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = navigationContext.Parameters["SelectedItem"] as Domain.Entities.ExperimentResult;
            Initialization();
        }

        #endregion

        #region 允许导航（不用在意）
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion
    }
}
