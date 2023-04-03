using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using NHibernate.Mapping;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;

namespace agent.ViewModels
{
	public class NewLearnAgentViewModel : BindableBase
	{
        #region 数据接口
        public DataBaseAccess<AgentLearningSch> AgentLearningSchAccess = new();
        #endregion

        #region 新建方案
        public AgentLearningSch NewItem { get; set; }

        //谣言配置
        private ObservableCollection<RumorLearningConfig> _rumorLearningConfigs;
        public ObservableCollection<RumorLearningConfig> RumorLearningConfigs
        {
            get { return _rumorLearningConfigs; }
            set
            {
                SetProperty(ref _rumorLearningConfigs, value);
            }
        }
        //经验配置
        private ObservableCollection<PropositionLearningConfig> _propositionLearningConfigs;
        public ObservableCollection<PropositionLearningConfig> PropositionLearningConfigs
        {
            get { return _propositionLearningConfigs; }
            set 
            { 
                SetProperty(ref _propositionLearningConfigs, value);
            }
        }

        #endregion

        #region 基本相关数据
        //选择个体数据集
        public IList<AgentSet> AgentSets { get; set; }
        private AgentSet _selectedAgentSet;
        public AgentSet SelectedAgentSet
        {
            get { return _selectedAgentSet; }
            set
            {
                SetProperty(ref _selectedAgentSet, value);
                if (value != null)
                {
                    var temp = new DataBaseAccess<NetworkSch>().GetByCondition(value, "AgentSet");
                    NetworkSches = new();
                    foreach (var i in temp)
                    {
                        NetworkSches.Add(i);
                    }
                }
            }
        }
        //选择网络方案
        private ObservableCollection<NetworkSch> _networkSches;
        public ObservableCollection<NetworkSch> NetworkSches
        {
            get { return _networkSches; }
            set { SetProperty(ref _networkSches, value); }
        }
        private NetworkSch _selectedNetworkSch;
        public NetworkSch SelectedNetworkSch
        {
            get { return _selectedNetworkSch; }
            set
            {
                SetProperty(ref _selectedNetworkSch, value);
                if (value != null)
                {
                    var temp = new DataBaseAccess<NetworkResult>().GetByCondition(value, "NetworkSch");
                    NetworkResults = new();
                    foreach (var i in temp)
                    {
                        NetworkResults.Add(i);
                    }
                }
            }
        }
        //选择网络结果方案
        private ObservableCollection<NetworkResult> _networkResults;
        public ObservableCollection<NetworkResult> NetworkResults
        {
            get { return _networkResults; }
            set { SetProperty(ref _networkResults, value); }
        }
        private NetworkResult _selectedNetworkResult;
        public NetworkResult SelectedNetworkResult
        {
            get { return _selectedNetworkResult; }
            set
            {
                if (value != null)
                {
                    NewItem.NetworkResult = value;
                    int i = 0;
                    foreach(var node in value.NetNodes)
                    {
                        node.id = i;
                        i++;
                    }
                }
                SetProperty(ref _selectedNetworkResult, value);
            }
        }
        #endregion

        #region 报错提示
        private Visibility _warning;
        public Visibility Warning
        {
            get { return _warning; }
            set { SetProperty(ref _warning, value); }
        }
        #endregion
        #region 切换下一步
        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set { SetProperty(ref _tabIndex, value); }
        }
        #endregion

        #region 初始化
        private void InitialNewItem()
        {
            Warning = Visibility.Hidden;
            TabIndex = 0;
            //InfoIndex = -1;

            AgentSets = new DataBaseAccess<AgentSet>().GetAll();
            NewItem = new()
            {
                Guid = Guid.NewGuid(),               
            };

            //RumorLearningConfigs = new();
            
            //PropositionLearningConfigs= new();

            //RumorQueues = new DataBaseAccess<RumorQueue>().GetAll().ToList();
            //propositionQueues = new DataBaseAccess<PropositionQueue>().GetAll().ToList();
        }
        #endregion

        #region 第一步：基础信息配置
        public DelegateCommand Next1 { get; private set; }
        public void Next1Method()
        {
            if (string.IsNullOrWhiteSpace(NewItem.Name) ||
                string.IsNullOrWhiteSpace(NewItem.CreateName))
            {
                Warning = Visibility.Visible;
            }
            else
            {
                Warning = Visibility.Hidden;
                TabIndex = 1;
            }
        }
        #endregion

        #region 第二步：网络结果配置
        public DelegateCommand<Window> Finish { get; private set; }
        public void FinishMethod(Window newwindow)
        {
            if (NewItem.NetworkResult == null)
            {
                Warning = Visibility.Visible;
            }
            else
            {
                NewItem.CreateTime = DateTime.Now;
                AgentLearningSchAccess.Add(NewItem);
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
        }
        #endregion

        #region Main
        public NewLearnAgentViewModel()
        {
            InitialNewItem();
            //SelectNetNode = new DelegateCommand<IList>(SelectNetNodeMethod);
            //AddInfosCommand = new DelegateCommand<IList>(AddInfosCommandMethod);
            //DeleteInfosCommand = new DelegateCommand<IList>(DeleteInfosCommandMethod);
            Next1 = new DelegateCommand(Next1Method);
            //Next2 = new DelegateCommand(Next2Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion


        #region 消息配置 已注释
        #region 消息配置相关数据 已注释
        ////可配置谣言队列方案
        //public List<RumorQueue> RumorQueues { get; set; }

        ////可配置经验队列方案
        //public List<PropositionQueue> propositionQueues { get; set; }


        ////选择配置的网络节点
        //private ObservableCollection<NetNode> _selectedNodes;
        //public ObservableCollection<NetNode> SelectedNodes
        //{
        //    get { return _selectedNodes; }
        //    set 
        //    {
        //        SetProperty(ref _selectedNodes, value);
        //    }
        //}

        ////已配置消息
        //private ObservableCollection<InfoData> _configedInfo;
        //public ObservableCollection<InfoData> ConfigedInfo
        //{
        //    get { return _configedInfo; }
        //    set { SetProperty(ref _configedInfo, value); }
        //}

        ////可配置消息
        //private ObservableCollection<InfoData> _configableInfo;
        //public ObservableCollection<InfoData> ConfigableInfo
        //{
        //    get { return _configableInfo; }
        //    set { SetProperty(ref _configableInfo, value); }
        //}

        ////选择的消息类型
        //private int _infoIndex;
        //public int InfoIndex
        //{
        //    get { return _infoIndex; }
        //    set 
        //    { 
        //        SetProperty(ref _infoIndex, value);
        //        Refresh();
        //    }
        //}
        #endregion
        //确定选定的待配置网络节点
        //public DelegateCommand<IList> SelectNetNode { get; private set; }
        //public void SelectNetNodeMethod(IList netnodes)
        //{
        //    SelectedNodes = new();
        //    if(netnodes.Count>0)
        //    {
        //        foreach(var i in netnodes)
        //        {                   
        //            SelectedNodes.Add((NetNode)i);
        //        }
        //    }
        //    InfoIndex = 0;
        //}
        //刷新
        //public void Refresh()
        //{
        //    if (InfoIndex == 0 && SelectedNodes.Count > 0)
        //    {
        //        ConfigedInfo = new();
        //        foreach (var node in SelectedNodes)
        //        {
        //            foreach (var i in RumorLearningConfigs)
        //            {
        //                if (i.NetNode == node)
        //                {
        //                    ConfigedInfo.Add(i.RumorQueue);
        //                }
        //            }
        //        }
        //        ConfigableInfo = new();
        //        foreach (var i in RumorQueues)
        //        {
        //            ConfigableInfo.Add(i);
        //        }
        //    }
        //    if (InfoIndex == 1 && SelectedNodes.Count > 0)
        //    {
        //        ConfigedInfo = new();
        //        foreach (var node in SelectedNodes)
        //        {
        //            foreach (var i in PropositionLearningConfigs)
        //            {
        //                if (i.NetNode == node)
        //                {
        //                    ConfigedInfo.Add(i.PropositionQueue);
        //                }
        //            }
        //        }
        //        ConfigableInfo = new();
        //        foreach (var i in propositionQueues)
        //        {
        //            ConfigableInfo.Add(i);
        //        }
        //    }
        //}

        ////消息删除
        //public DelegateCommand<IList> DeleteInfosCommand { get; private set; }
        //public void DeleteInfosCommandMethod(IList deleteInfos)
        //{
        //    if (deleteInfos.Count > 0 && SelectedNodes.Count > 0)
        //    {
        //        if (InfoIndex == 0)
        //        {
        //            foreach (var netNode in SelectedNodes)
        //            {
        //                foreach (var deleteinfo in deleteInfos)
        //                {
        //                    foreach (var rumorLearningConfig in RumorLearningConfigs)
        //                    {
        //                        if(rumorLearningConfig.NetNode == netNode && rumorLearningConfig.RumorQueue == deleteinfo)
        //                        {
        //                            RumorLearningConfigs.Remove(rumorLearningConfig);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (InfoIndex == 1)
        //        {
        //            foreach (var netNode in SelectedNodes)
        //            {
        //                foreach (var deleteinfo in deleteInfos)
        //                {
        //                    foreach (var propositionLearningConfig in PropositionLearningConfigs)
        //                    {
        //                        if (propositionLearningConfig.NetNode == netNode && propositionLearningConfig.PropositionQueue == deleteinfo)
        //                        {
        //                            PropositionLearningConfigs.Remove(propositionLearningConfig);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        Refresh();
        //    }
        //}

        ////消息添加
        //public DelegateCommand<IList> AddInfosCommand { get; private set; }
        //public void AddInfosCommandMethod(IList addInfos)
        //{
        //    if(addInfos.Count>0 && SelectedNodes.Count>0)
        //    {
        //        if(InfoIndex == 0)
        //        {
        //            foreach(NetNode netnode in SelectedNodes)
        //            {
        //                foreach (var addinfo in addInfos)
        //                {                           
        //                    RumorLearningConfigs.Add(new RumorLearningConfig
        //                    {
        //                        Guid = Guid.NewGuid(),
        //                        AgentLearningSch = NewItem,
        //                        NetNode = netnode,
        //                        RumorQueue = (RumorQueue)addinfo
        //                    });
        //                }
        //            }
        //        }
        //        if(InfoIndex == 1)
        //        {
        //            foreach (NetNode netnode in SelectedNodes)
        //            {
        //                foreach (var addinfo in addInfos)
        //                {
        //                    PropositionLearningConfigs.Add(new PropositionLearningConfig
        //                    {
        //                        Guid = Guid.NewGuid(),
        //                        AgentLearningSch = NewItem,
        //                        NetNode = netnode,
        //                        PropositionQueue = (PropositionQueue)addinfo
        //                    });
        //                }
        //            }
        //        }
        //        Refresh();
        //    }
        //}
        #endregion
    }
}
