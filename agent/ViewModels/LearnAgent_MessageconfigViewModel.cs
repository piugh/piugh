using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Windows;

namespace agent.ViewModels
{
	public class LearnAgent_MessageconfigViewModel : BindableBase, INavigationAware
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
                if (value != null)
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
        #endregion

        #region 节点筛选
        //显示个体
        private ObservableCollection<NetNode> _netNodes;
        public ObservableCollection<NetNode> NetNodes
        {
            get { return _netNodes; }
            set { SetProperty(ref _netNodes, value); }
        }
        //筛选属性
        private int _selectPropoerty;
        public int SelectPropoerty
        {
            get { return _selectPropoerty; }
            set
            {
                SetProperty(ref _selectPropoerty, value);
                if (SelectedItem != null)
                {
                    PropertyValue.Clear();
                    PropertyValue.Add(new InfoData { Name = "请选择属性值" });
                    //性别
                    if (value == 1)
                    {
                        PropertyValue.Add(new InfoData { Name = "FEMALE" });
                        PropertyValue.Add(new InfoData { Name = "MALE" });
                    }
                    //年龄
                    if (value == 2)
                    {
                        var temp = new DataBaseAccess<AgeLevel>().GetAll().ToList();
                        foreach (var i in temp)
                        {
                            PropertyValue.Add(i);
                        }
                    }
                    //职业
                    if (value == 3)
                    {
                        var temp = new DataBaseAccess<Occupation>().GetAll().ToList();
                        foreach (var i in temp)
                        {
                            PropertyValue.Add(i);
                        }
                    }
                    //受教育程度
                    if (value == 4)
                    {
                        var temp = new DataBaseAccess<EduLevel>().GetAll().ToList();
                        foreach (var i in temp)
                        {
                            PropertyValue.Add(i);
                        }
                    }
                    SelectedPropoertyValue = PropertyValue[0];
                }
            }
        }
        //可选择的属性值
        private ObservableCollection<InfoData> _proportyValue;
        public ObservableCollection<InfoData> PropertyValue
        {
            get { return _proportyValue; }
            set { SetProperty(ref _proportyValue, value); }
        }
        //选择的属性值
        private InfoData _selectedPropoertyValue;
        public InfoData SelectedPropoertyValue
        {
            get { return _selectedPropoertyValue; }
            set
            {
                SetProperty(ref _selectedPropoertyValue, value);
                if (value != null && value.Name != "请选择属性值")
                {
                    List<NetNode> temp = new();
                    //性别
                    if (SelectPropoerty == 1)
                    {
                        temp = (from i in SelectedItem.NetworkResult.NetNodes where i.AgentProperty.Gender == value.Name select i).ToList();
                    }
                    //年龄
                    if (SelectPropoerty == 2)
                    {
                        temp = (from i in SelectedItem.NetworkResult.NetNodes where i.AgentProperty.AgeLevel.Name == value.Name select i).ToList();
                    }
                    //职业
                    if (SelectPropoerty == 3)
                    {
                        temp = (from i in SelectedItem.NetworkResult.NetNodes where i.AgentProperty.Occupation.Name == value.Name select i).ToList();
                    }
                    //受教育程度
                    if (SelectPropoerty == 4)
                    {
                        temp = (from i in SelectedItem.NetworkResult.NetNodes where i.AgentProperty.EduLevel.Name == value.Name select i).ToList();
                    }
                    NetNodes.Clear();
                    foreach (var i in temp)
                    {
                        NetNodes.Add(i);
                    }
                }
                else
                {
                    NetNodes = new();
                    foreach (var i in SelectedItem.NetworkResult.NetNodes)
                    {
                        NetNodes.Add(i);
                    }
                }
            }
        }
#endregion

        #region 节点信息
        //是否选中节点
        private bool _selectNodeCheck;
        public bool SelectNodeCheck
        {
            get { return _selectNodeCheck; }
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
            ConfigableInfo = new();
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
                foreach (var rumorQueue in RumorQueues)
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
            NetNodes = new();
            PropertyValue = new();
            SelectPropoerty = 0;
            SelectNodeCheck = false;
            RumorQueues = new DataBaseAccess<RumorQueue>().GetAll().ToList();
            PropositionQueues = new DataBaseAccess<PropositionQueue>().GetAll().ToList();
        }
        #endregion

        #region Main
        public LearnAgent_MessageconfigViewModel()
        {
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
