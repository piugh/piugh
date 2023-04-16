using Data;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;

namespace Experiment.ViewModels
{
    public class NewExperimentItemViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<Domain.Entities.Experiment> ExperimentAccess = new();
        #endregion

        #region 新建个体集方案
        public Domain.Entities.Experiment NewItem { get; set; }
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

        #region 相关数据
        //可选个体集
        private List<AgentSet> _agentSets;
        public List<AgentSet> AgentSets
        {
            get { return _agentSets; }
            set
            {
                SetProperty(ref _agentSets, value);
            }
        }
        private AgentSet _selectedAgentSet;
        public AgentSet SelectedAgentSet
        {
            get { return _selectedAgentSet; }
            set
            {
                SetProperty(ref _selectedAgentSet, value);
                if (value != null)
                {
                    NewItem.AgentSet = value;
                    NetworkSches = new();
                    var temp = new DataBaseAccess<NetworkSch>().GetByCondition(value, "AgentSet").ToList();
                    if(temp!=null)
                    {
                        foreach (var i in temp)
                        {
                            NetworkSches.Add(i);
                        }
                    }
                }
            }
        }

        //可选网络方案
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
                    NetworkResults= new();
                    var temp = new DataBaseAccess<NetworkResult>().GetByCondition(value, "NetworkSch");
                    if(temp!=null)
                    {
                        foreach (var i in temp)
                        {
                            NetworkResults.Add(i);
                        }
                    }

                }
            }
        }

        //可选网络结果
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
                SetProperty(ref _selectedNetworkResult, value);
                if (value != null)
                {
                    NewItem.NetworkResult= value;
                    AgentLearningSches= new();
                    var temp = new DataBaseAccess<AgentLearningSch>().GetByCondition(value, "NetworkResult");
                    if(temp !=null)
                    {
                        foreach (var i in temp)
                        {
                            AgentLearningSches.Add(i);
                        }
                    }
                }
            }
        }

        //可选个体学习方案
        private ObservableCollection<AgentLearningSch> _agentLearningSches;
        public ObservableCollection<AgentLearningSch> AgentLearningSches
        {
            get { return _agentLearningSches; }
            set { SetProperty(ref _agentLearningSches, value); }
        }

        //可选谣言
        private List<Rumor> _rumors;
        public List<Rumor> Rumors
        {
            get { return _rumors; }
            set { SetProperty(ref _rumors, value); }
        }
        #endregion

        #region 初始化
        private void InitialNewItem()
        {
            Warning = Visibility.Hidden;
            TabIndex = 0;
            //基础信息初始化
            NewItem = new Domain.Entities.Experiment()
            {
                Guid = Guid.NewGuid(),
            };
            //相关数据获取
            Rumors = new DataBaseAccess<Rumor>().GetAll().ToList();
            AgentSets = new DataBaseAccess<AgentSet>().GetAll().ToList();
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

        #region 第二步：完成配置
        public DelegateCommand<Window> Finish { get; private set; }
        public void FinishMethod(Window newwindow)
        {
            if (NewItem.NetworkResult!=null && NewItem.AgentSet!=null && NewItem.AgentLearningSch!=null && NewItem.Rumor!=null)
            {
                NewItem.CreateTime = DateTime.Now;
                ExperimentAccess.Add(NewItem);
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
            else
            {
                Warning = Visibility.Visible;
            }
        }
        #endregion

        #region Main
        public NewExperimentItemViewModel()
        {
            InitialNewItem();
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);

        }
        #endregion
    }
}
