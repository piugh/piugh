using Data;
using Domain.Entities;
using Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace agent.ViewModels
{
	public class InitialAgent_AgentSetTableViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        //所选个体集方案个体列表
        private AgentSet _selectedItem;
        public AgentSet SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
        #endregion

        #region 数据筛选
        //显示个体
        private ObservableCollection<Domain.Entities.Agent> _agents;
        public ObservableCollection<Domain.Entities.Agent> Agents
        {
            get { return _agents; }
            set { SetProperty(ref _agents, value); }
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
                        PropertyValue.Add(new InfoData { Name = "男" });
                        PropertyValue.Add(new InfoData { Name = "女" });
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
                    List<Domain.Entities.Agent> temp = new();
                    //性别
                    if (SelectPropoerty == 1)
                    {
                        temp = (from i in SelectedItem.Agents where i.Gender == value.Name select i).ToList();
                    }
                    //年龄
                    if (SelectPropoerty == 2)
                    {
                        temp = (from i in SelectedItem.Agents where i.AgeLevel.Name == value.Name select i).ToList();
                    }
                    //职业
                    if (SelectPropoerty == 3)
                    {
                        temp = (from i in SelectedItem.Agents where i.Occupation.Name == value.Name select i).ToList();
                    }
                    //受教育程度
                    if (SelectPropoerty == 4)
                    {
                        temp = (from i in SelectedItem.Agents where i.EduLevel.Name == value.Name select i).ToList();
                    }
                    Agents.Clear();
                    foreach (var i in temp)
                    {
                        Agents.Add(i);
                    }
                }
                else
                {
                    Agents = new();
                    foreach (var i in SelectedItem.Agents)
                    {
                        Agents.Add(i);
                    }
                }
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            int id = 1;
            if (SelectedItem.Agents == null)
                return;
            foreach (Agent agent in SelectedItem.Agents)
            {
                agent.id = id;
                id++;
            }
            Agents = new();
            PropertyValue = new();
            SelectPropoerty = 0;
        }
        #endregion

        #region Main
        public InitialAgent_AgentSetTableViewModel()
        {
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = navigationContext.Parameters["SelectedItem"] as AgentSet;
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
