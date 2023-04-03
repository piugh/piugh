using Domain;
using Prism.Common;
using Prism.Regions;
using Resource.ViewModels;
using System;
using System.Windows.Controls;

namespace Resource.Views
{
    /// <summary>
    /// Interaction logic for BaseInfoView
    /// </summary>
    public partial class BaseInfoView : UserControl
    {
        public BaseInfoView()
        {
            InitializeComponent();
            RegionContext.GetObservableContext(this).PropertyChanged += SelectedItemChanged;
        }
        private void SelectedItemChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var selectedItem = (InfoData)context.Value;
            ((BaseInfoViewModel)DataContext).SelectedItem = selectedItem;
        }

    }
}
