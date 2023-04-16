using Data;
using Domain.Entities;
using NHibernate.Mapping;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Experiment.ViewModels
{
    public class ExperimentResult_OverviewViewModel : BindableBase, INavigationAware
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

        #region 相关数据
        private ObservableCollection<SpreadInfo> _spreadInfos;

        public ObservableCollection<SpreadInfo> SpreadInfos
        {
            get { return _spreadInfos; }
            set
            {
                SetProperty(ref _spreadInfos, value);
            }
        }
        //产生步长总数
        private int _stepCount;
        public int StepCount
        {
            get { return _stepCount; }
            set { SetProperty(ref _stepCount, value); }
        }
        //单位步长传递消息数
        private int _infoByEveryStep;
        public int InfoByEveryStep
        {
            get { return _infoByEveryStep; }
            set { SetProperty(ref _infoByEveryStep, value); }
        }
        //最终步传递消息数
        private int _lastStepInfoCount;
        public int LastStepInfoCount
        {
            get { return _lastStepInfoCount; }
            set { SetProperty(ref _lastStepInfoCount, value); }
        }
        //最终步长消息
        private SpreadInfo _lastInfo;
        public SpreadInfo LastInfo
        {
            get { return _lastInfo; }
            set { SetProperty(ref _lastInfo, value); }
        }

        //传播最多的消息
        private string _widelyInfo;
        public string WidelyInfo
        {
            get { return _widelyInfo; }
            set { SetProperty(ref _widelyInfo, value); }
        }
        private int _widelyInfoCount;
        public int WidelyInfoCount
        {
            get { return _widelyInfoCount; }
            set { SetProperty(ref _widelyInfoCount, value); }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            //获取传递消息
            SpreadInfos = new();
            var temp = SelectedItem.SpreadInfos.ToList();
            foreach (var i in temp)
            {
                SpreadInfos.Add(i);
            }

            //传递步长、单位步长传递消息数目、最后传递消息数目、最后传递消息
            StepCount = SpreadInfos.OrderBy(i => i.Step).Count();
            InfoByEveryStep = SpreadInfos.Count / StepCount;
            LastStepInfoCount = SpreadInfos.Where(i => i.Step == SpreadInfos.Max(i => i.Step)).Count();
            LastInfo = SpreadInfos.Last();

            //传播次数最多的消息
            Dictionary<string, int> MeanstringDic = new Dictionary<string, int>();
            int maxcount = 0;
            string tempstring = SpreadInfos[0].MeanString;
            foreach (var a in SpreadInfos)
            {
                if (MeanstringDic.ContainsKey(a.MeanString))
                {
                    MeanstringDic[a.MeanString] += 1;
                    if (maxcount < MeanstringDic[a.MeanString])
                    {
                        maxcount = MeanstringDic[a.MeanString];
                        tempstring = a.MeanString;
                    }
                }
                else
                {
                    MeanstringDic.Add(a.MeanString, 1);
                }
            }
            WidelyInfo = tempstring;
            WidelyInfoCount = MeanstringDic[tempstring];

        }
        #endregion

        #region Main
        public ExperimentResult_OverviewViewModel()
        {

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
