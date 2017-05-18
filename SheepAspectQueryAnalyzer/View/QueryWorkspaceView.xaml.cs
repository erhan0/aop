using System.Windows;
using System.Windows.Controls;
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
            if (e.NewValue is QueryWorkspaceVm vm)
            {
                vm.RequestSelectedQueryText += () => txtQuery.SelectedText;
            }
        }
    }
}
