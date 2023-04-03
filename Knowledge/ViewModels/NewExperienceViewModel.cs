using Antlr.Runtime.Misc;
using Data;
using Domain.Information.Entities;
using NHibernate.Cfg;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Knowledge.ViewModels
{
    public class NewExperienceViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<Proposition> PropositionAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private Proposition _newItem;
        public Proposition NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //细节信息
        public IList<Domain.Information.Entities.Action> Actions { get; set; }
        public IList<Aspiration> Aspirations { get; set; }
        public IList<Domain.Information.Entities.Environment> Environments { get; set; }
        public IList<Rumor> Rumors { get; set; }
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
            //相关配置数据
            Actions = new DataBaseAccess<Domain.Information.Entities.Action>().GetAll();
            Environments = new DataBaseAccess<Domain.Information.Entities.Environment>().GetAll();
            Aspirations = new DataBaseAccess<Aspiration>().GetAll();
            Rumors = new DataBaseAccess<Rumor>().GetAll();

            //基础信息初始化
            NewItem = new Proposition()
            {
                Guid = Guid.NewGuid(),
            };         
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
            NewItem.CreateTime = DateTime.Now;
            PropositionAccess = new();
            //二进制
            NewItem.EumBinary = "";
            NewItem.EumBinary += NewItem.Environment.EumBinary + ",";
            NewItem.EumBinary += NewItem.Rumor.RumorEumBinary + ",";
            NewItem.EumBinary += Convert.ToInt16(NewItem.Attitude).ToString();
            NewItem.EumBinary += ",";
            NewItem.EumBinary += NewItem.Action.EumBinary +",";
            NewItem.EumBinary += NewItem.Aspiration.EumBinary;
            PropositionAccess.Add(NewItem);
            NHibernateHelper.CloseSession();
            newwindow.Close();
        }

        #endregion

        #region Main
        public NewExperienceViewModel()
        {
            InitialNewItem();
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion


    }
}
