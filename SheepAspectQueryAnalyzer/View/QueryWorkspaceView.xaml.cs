using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SheepAspectQueryAnalyzer.ViewModel;

namespace SheepAspectQueryAnalyzer.View
{
    /// <summary>
    /// Interaction logic for QueryWorkspaceView.xaml
    /// </summary>
    public partial class QueryWorkspaceView : UserControl
    {
        public QueryWorkspaceView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var vm = e.NewValue as QueryWorkspaceVm;
            if (vm != null)
                vm.RequestSelectedQueryText += () => txtQuery.SelectedText;
        }
    }
}
