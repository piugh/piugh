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
    public class ExperimentResult_InforesultViewModel : BindableBase, INavigationAware
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

        private ObservableCollection<SpreadInfo> _allSpreadInfos;
        public ObservableCollection<SpreadInfo> AllSpreadInfos
        {
            get { return _allSpreadInfos; }
            set { SetProperty(ref _allSpreadInfos, value); }
        }

        #endregion

        #region 数据筛选

        private ObservableCollection<SpreadInfo> _spreadInfos;
        public ObservableCollection<SpreadInfo> SpreadInfos
        {
            get { return _spreadInfos; }
            set { SetProperty(ref _spreadInfos, value); }
        }

        //数据发送方or接收方
        private int _sendorReceive;
        public int SendorReceive
        {
            get { return _sendorReceive; }
            set
            {
                SetProperty(ref _sendorReceive, value);
                SpreadInfoFilter();
            }
        }

        //仿真步数
        private ObservableCollection<string> _stepList;
        public ObservableCollection<string> StepList
        {
            get { return _stepList; }
            set { SetProperty(ref _stepList, value); }
        }
        private string _selectedStep;
        public string SelectedStep
        {
            get { return _selectedStep; }
            set
            {
                SetProperty(ref _selectedStep, value);
                SpreadInfoFilter();
            }
        }

        //个体ID
        private ObservableCollection<string> _agentIDs;
        public ObservableCollection<string> AgentIDs
        {
            get { return _agentIDs; }
            set { SetProperty(ref _agentIDs, value); }
        }
        private string _selectedAgentID;
        public string SelectedAgentID
        {
            get { return _selectedAgentID; }
            set
            {
                SetProperty(ref _selectedAgentID, value);
                SpreadInfoFilter();
            }
        }

        //消息筛选
        private void SpreadInfoFilter()
        {
            List<SpreadInfo> temp = new();
            foreach(var i in AllSpreadInfos)
            {
                temp.Add(i);
            }

            //根据个体筛选
            if (SendorReceive == 0)  //无限制
            {
                temp.RemoveAll(x => SelectedAgentID != "无限制" && 
                               !(x.Send.id.ToString() == SelectedAgentID || x.Receive.id.ToString() == SelectedAgentID));
            }
            if (SendorReceive == 1)  //发送方
            {
                temp.RemoveAll(x => SelectedAgentID != "无限制" && x.Send.id.ToString() != SelectedAgentID);
            }
            if (SendorReceive == 2)  //接收方
            {
                temp.RemoveAll(x => SelectedAgentID != "无限制" && x.Receive.id.ToString() != SelectedAgentID);
            }

            //根据步长删除
            temp.RemoveAll(x => SelectedStep != "无限制" && x.Step.ToString() != SelectedStep);

            SpreadInfos.Clear();
            foreach(var i in temp)
            {
                SpreadInfos.Add(i);
            }

        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            ////获取全部传递消息
            //AllSpreadInfos = new();
            //List<SpreadInfo> temp = SelectedItem.SpreadInfos.ToList();
            //temp.OrderBy(i => i.Step).ToList();
            //int id = 1;
            //foreach (SpreadInfo spreadInfo in temp)
            //{
            //    spreadInfo.Send.id = id;
            //    spreadInfo.Receive.id = id + 1;
            //    AllSpreadInfos.Add(new SpreadInfo()
            //    {
            //        Guid = spreadInfo.Guid,
            //        Send = spreadInfo.Send,
            //        Receive = spreadInfo.Receive,
            //        Step = spreadInfo.Step,
            //        RumorString = spreadInfo.RumorString,
            //        MeanString = DataConvert.StringToRumor(spreadInfo.RumorString).MeanString
            //    });
            //    id++;
            //}
            AllSpreadInfos = new();
            var temp = SelectedItem.SpreadInfos.ToList();
            foreach(var i in temp)
            {
                AllSpreadInfos.Add(i);
            }
            SpreadInfos = new();
            AgentIDs = new();
            StepList = new();
            AgentIDs.Add("无限制");
            StepList.Add("无限制");
            foreach (var i in AllSpreadInfos)
            {
                if(!AgentIDs.Contains(i.Send.id.ToString()))
                {
                    AgentIDs.Add(i.Send.id.ToString());
                }
                if (!AgentIDs.Contains(i.Receive.id.ToString()))
                {
                    AgentIDs.Add(i.Receive.id.ToString());
                }

                if(!StepList.Contains(i.Step.ToString()))
                {
                    StepList.Add(i.Step.ToString());
                }
            }
        }
        #endregion

        #region Main
        public ExperimentResult_InforesultViewModel()
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
