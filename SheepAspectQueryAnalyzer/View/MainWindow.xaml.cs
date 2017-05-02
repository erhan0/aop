using System;
using System.Windows;
using SheepAspectQueryAnalyzer.ViewModel;

namespace SheepAspectQueryAnalyzer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowVm vm)
        {
            InitializeComponent();

            // Bind View with ViewModel
            DataContext = vm;

            // Bind View event
            vm.RequestClose += delegate { Close(); };
            vm.RequestOpenAssembliesView += OpenAssembliesView;
        }

        private static void OpenAssembliesView(LoadedAssembliesVm obj)
        {
            new LoadedAssembliesView(obj).ShowDialog();
        }
    }
}
