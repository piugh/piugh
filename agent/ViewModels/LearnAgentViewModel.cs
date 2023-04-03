using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using NHibernate.Mapping;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Resource.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace agent.ViewModels
{
    public class LearnAgentViewModel : BindableBase,INavigationAware
    {
        #region 当前方案    
        //选中的方案
        private AgentLearningSch _selectedItem;
        public AgentLearningSch SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                SetProperty(ref _selectedItem, value);
                if (value!= null ) 
                {
                    int id = 1;
                    foreach (var i in SelectedItem.NetworkResult.NetNodes)
                    {
                        i.id = id;
                        id++;
                    }
                }
            }
        }
        //选择的网络节点
        private ObservableCollection<NetNode> _selectedNodes;
        public ObservableCollection<NetNode> SelectedNodes
        {
            get { return _selectedNodes; }
            set
            {
                SetProperty(ref _selectedNodes, value);
            }
        }
        //网络节点
        public IList<NetNode> NetNodes { get; set; }
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
                if (value == 0)
                {
                    IRegion region = _regionManager.Regions["LearnAgentBaseInfoRegion"];
                    region.RemoveAll();
                    _regionManager.RegisterViewWithRegion("LearnAgentBaseInfoRegion", typeof(BaseInfoView));
                }
            }
        }
        #endregion

        #region 节点信息
        //是否选中节点
        private bool _selectNodeCheck;
        public bool SelectNodeCheck 
        {
            get{ return _selectNodeCheck; }
            set { SetProperty(ref _selectNodeCheck, value); }
        }
        //配置信息类型
        private int _infoIndex;
        public int InfoIndex
        {
            get { return _infoIndex; }
            set
            {
                SetProperty(ref _infoIndex, value);
                Refresh();
            }
        }
        //选中节点对应的配置信息
        private ObservableCollection<InfoData> _configedInfo;
        public ObservableCollection<InfoData> ConfigedInfo
        {
            get { return _configedInfo; }
            set { SetProperty(ref _configedInfo, value); }
        }
        //可配置的信息
        private ObservableCollection<InfoData> _configableInfo;
        public ObservableCollection<InfoData> ConfigableInfo
        {
            get { return _configableInfo; }
            set { SetProperty(ref _configableInfo, value); }
        }

        public List<RumorQueue> RumorQueues { get; set; }
        public List<PropositionQueue> PropositionQueues { get; set; }


        #endregion

        #region 节点消息配置
        public DelegateCommand<IList> SelectedNodesCommand { get; private set; }
        public void SelectedNodesMethod(IList netnodes)
        {
            SelectedNodes = new();
            if (netnodes.Count > 0)
            {
                foreach (var i in netnodes)
                {
                    SelectedNodes.Add((NetNode)i);
                }
                SelectNodeCheck = true;
                InfoIndex = 0;
            }
            Refresh();
        }
        public void Refresh()
        {
            ConfigedInfo = new(); 
            ConfigableInfo= new();
            if (InfoIndex == 0 && SelectedNodes.Count > 0)
            {
                foreach (var node in SelectedNodes)
                {
                    foreach (var i in SelectedItem.RumorLearningConfigs)
                    {
                        if (i.NetNode == node)
                        {
                            ConfigedInfo.Add(i.RumorQueue);
                        }
                    }
                }
                foreach(var rumorQueue in RumorQueues)
                {
                    ConfigableInfo.Add(rumorQueue);
                }
            }
            if (InfoIndex == 1 && SelectedNodes.Count > 0)
            {
                foreach (var node in SelectedNodes)
                {
                    foreach (var i in SelectedItem.PropositionLearningConfigs)
                    {
                        if (i.NetNode == node)
                        {
                            ConfigedInfo.Add(i.PropositionQueue);
                        }
                    }
                }
                foreach (var Queue in PropositionQueues)
                {
                    ConfigableInfo.Add(Queue);
                }
            }
        }

        public DelegateCommand<IList> AddInfosCommand { get; set; }
        public void AddInfosMethod(IList list)
        {
            if (list.Count > 0 && SelectedNodes.Count > 0)
            {
                if (InfoIndex == 0)
                {
                    DataBaseAccess<RumorLearningConfig> tempAccess = new DataBaseAccess<RumorLearningConfig>();
                    foreach (NetNode i in SelectedNodes)
                    {
                        //先获取当前个体所有配置，并删除
                        IList<RumorLearningConfig> tempDelete
                            = tempAccess.GetByCondition(i, "NetNode", SelectedItem, "AgentLearningSch");
                        foreach (var d in tempDelete)
                        {
                            tempAccess.DeleteT(d);
                        }
                        //添加当前配置信息
                        foreach (RumorQueue a in list)
                        {
                            tempAccess.Add(new RumorLearningConfig()
                            {
                                Guid = Guid.NewGuid(),
                                AgentLearningSch = SelectedItem,
                                NetNode = i,
                                RumorQueue = a,
                            });
                        }
                    }
                }
                if (InfoIndex == 1)
                {
                    var tempAccess = new DataBaseAccess<PropositionLearningConfig>();
                    foreach (NetNode i in SelectedNodes)
                    {
                        //先获取当前个体所有配置，并删除
                        IList<PropositionLearningConfig> tempDelete
                            = tempAccess.GetByCondition(i, "NetNode", SelectedItem, "AgentLearningSch");
                        foreach (PropositionLearningConfig d in tempDelete)
                        {
                            tempAccess.Delete(d.GetType().Name, d);
                        }
                        //添加当前配置信息
                        foreach (PropositionQueue a in list)
                        {
                            tempAccess.Add(new PropositionLearningConfig()
                            {
                                Guid = Guid.NewGuid(),
                                AgentLearningSch = SelectedItem,
                                NetNode = i,
                                PropositionQueue = a,
                            });
                        }
                    }
                }
                MessageBox.Show("已添加完成");
                var temp = new DataBaseAccess<AgentLearningSch>().GetByCondition(SelectedItem.Guid, "Guid");
                SelectedItem = temp[0];
                Refresh();
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            SelectNodeCheck = false;
            RumorQueues = new DataBaseAccess<RumorQueue>().GetAll().ToList();
            PropositionQueues = new DataBaseAccess<PropositionQueue>().GetAll().ToList();
            TabIndex = 0;
        }
        #endregion

        #region Main
        public LearnAgentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SelectedNodesCommand = new DelegateCommand<IList>(SelectedNodesMethod);
            AddInfosCommand = new DelegateCommand<IList>(AddInfosMethod);
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (AgentLearningSch)navigationContext.Parameters["SelectedItem"];
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
