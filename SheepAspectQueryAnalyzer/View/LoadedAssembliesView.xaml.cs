using System.Windows;
using SheepAspectQueryAnalyzer.ViewModel;

namespace SheepAspectQueryAnalyzer.View
{
    /// <summary>
    /// Interaction logic for LoadedAssembliesView.xaml
    /// </summary>
    public partial class LoadedAssembliesView : Window
    {
        public LoadedAssembliesView(LoadedAssembliesVm vm)
        {
            InitializeComponent();

            vm.OnCloseRequested += Close;
            DataContext = vm;
        }
    }
}
