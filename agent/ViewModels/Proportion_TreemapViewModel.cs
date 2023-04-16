using Data;
using Domain.Entities;
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
	public class Proportion_TreemapViewModel : BindableBase, INavigationAware
    {
        #region 数据接口
        public DataBaseAccess<OccupationConfig> OccupationConfigAccess;
        public DataBaseAccess<EduLevelConfig> EduLevelConfigAccess;
        public DataBaseAccess<AgeLevelConfig> AgeLevelConfigAccess;
        #endregion

        #region 当前选中的方案
        private AgentSetProportion _selectedItem;
        public AgentSetProportion SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        private ObservableCollection<TreeData> _treeDatas;
        public ObservableCollection<TreeData> TreeDatas
        {
            get { return _treeDatas; }
            set
            {
                SetProperty(ref _treeDatas, value);
            }
        }
        #endregion

        #region 统计比例的树型结构
        //用到的配置信息
        private IList<OccupationConfig> MyOccupationConfigs { get; set; }
        private IList<AgeLevelConfig> MyAgeLevelConfigs { get; set; }
        private IList<EduLevelConfig> MyEduLevelConfigs { get; set; }

        public void GetTree(AgentSetProportion MyItem)
        {
            TreeDatas.Clear();
            //个体信息比例配置
            MyOccupationConfigs = OccupationConfigAccess.GetByCondition(MyItem, "AgentSetProportion");

            Gender gender_men = new();
            gender_men.Name = "男";
            Gender gender_women = new();
            gender_women.Name = "女";

            foreach (OccupationConfig occupationConfig in MyOccupationConfigs)
            {
                TreeData tmp_occupation = new()
                {
                    Classify = occupationConfig.Occupation,
                    Value = occupationConfig.Value,
                };
                MyEduLevelConfigs = EduLevelConfigAccess.GetByCondition
                    (SelectedItem, "AgentSetProportion",
                    occupationConfig, "OccupationConfig");
                foreach (EduLevelConfig eduLevelConfig in MyEduLevelConfigs)
                {
                    TreeData tmp_edu = new()
                    {
                        Classify = eduLevelConfig.EduLevel,
                        Value = eduLevelConfig.Value,
                    };
                    MyAgeLevelConfigs = AgeLevelConfigAccess.GetByCondition(SelectedItem, "AgentSetProportion",
                        eduLevelConfig, "EduLevelConfig");
                    foreach (AgeLevelConfig ageLevelConfig in MyAgeLevelConfigs)
                    {
                        TreeData temp_ageLevel = new()
                        {
                            Classify = ageLevelConfig.AgeLevel,
                            Value = ageLevelConfig.Value,
                        };
                        {
                            TreeData tmp_gender1 = new() { Classify = gender_men, Value = ageLevelConfig.MenProportion };
                            TreeData tmp_gender2 = new() { Classify = gender_women, Value = ageLevelConfig.WomenProportion };
                            temp_ageLevel.TreeDatas.Add(tmp_gender1);
                            temp_ageLevel.TreeDatas.Add(tmp_gender2);
                        }
                        tmp_edu.TreeDatas.Add(temp_ageLevel);
                    }
                    tmp_occupation.TreeDatas.Add(tmp_edu);
                }
                TreeDatas.Add(tmp_occupation);
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            //数据接口初始化
            OccupationConfigAccess = new();
            EduLevelConfigAccess = new();
            AgeLevelConfigAccess = new();
            //方案数据初始化
            TreeDatas = new();
            GetTree(SelectedItem);
        }
        #endregion

        #region Main
        public Proportion_TreemapViewModel()
        {

        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (AgentSetProportion)navigationContext.Parameters["SelectedItem"];
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
