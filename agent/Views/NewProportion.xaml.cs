using agent.Data;
using agent.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace agent.Views
{
    /// <summary>
    /// Interaction logic for NewProportion.xaml
    /// </summary>
    public partial class NewProportion : Window
    {
        public NewProportion()
        {
            InitializeComponent();
            var vm = new NewProportionViewModel();
            DataContext = vm;               
        }

    }
}
