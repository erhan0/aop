using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using SheepAspectQueryAnalyzer.Common;
using SheepAspectQueryAnalyzer.Properties;
using SheepAspectQueryAnalyzer.Helpers;
using System.Linq;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public class MainWindowVm: WorkspaceVm
    {
        private int _lastQueryWorkspaceIndex = 0;
        private readonly WorkspaceHolder _workspaceHolder = new WorkspaceHolder();
        private readonly ObservableCollection<IconCommandVm> _toolbarCommands = new ObservableCollection<IconCommandVm>();
        private readonly ICollection<string> _assemblies = new List<string>();
        private readonly Dispatcher _uiDispatcher;

        public MainWindowVm()
		{
            _uiDispatcher = Application.Current.Dispatcher;
            
			base.DisplayName = Texts.MainWindow_DisplayName;

            ShowTargetAssembliesCommand = new ActionCommand(x => ShowTargetAssemblies());
            NewQueryCommand = new ActionCommand(x => AddQueryWorkspace());
            CloseAllQueriesCommand = new ActionCommand(x => _workspaceHolder.CloseAll());

            Commands.Add(new IconCommandVm(Texts.Command_NewQueryWorkspace, Images.Command_NewQueryWorkspace.ToImageSource(), NewQueryCommand));
            Commands.Add(new IconCommandVm(Texts.Command_AddDll, Images.Command_AddAssembly.ToImageSource(), new ActionCommand(x=> AddDll())));

            RefreshToolbarMenu();
            ToolbarCommands = new ReadOnlyObservableCollection<IconCommandVm>(_toolbarCommands);

            Commands.CollectionChanged += delegate { RefreshToolbarMenu(); };
            _workspaceHolder.CurrentChanged += delegate { RefreshToolbarMenu(); };
            
            AddQueryWorkspace();
		}

        public ICommand CloseAllQueriesCommand { get; set; }

        protected void AddDll()
        {
            var asmVm = new LoadedAssembliesVm(_assemblies);
            _uiDispatcher.BeginInvoke(new Action(asmVm.Add));
            RequestOpenAssembliesView(asmVm);
        }

        public ICommand ShowTargetAssembliesCommand { get; private set; }
        public ICommand NewQueryCommand { get; private set; }

        private void RefreshToolbarMenu()
        {
            _toolbarCommands.Clear();

            foreach(var c in Commands.OfType<IconCommandVm>())
                _toolbarCommands.Add(c);

            var activeWorkspace = _workspaceHolder.CurrentWorkspace;
            if(activeWorkspace != null)
                foreach(var c in activeWorkspace.Commands.OfType<IconCommandVm>())
                    _toolbarCommands.Add(c);
        }

        /// <summary>
		/// Returns the collection of available workspaces to display.
		/// A 'workspace' is a ViewModel that can request to be closed.
		/// </summary>
		public ReadOnlyObservableCollection<WorkspaceVm> Workspaces
		{
			get
			{
			    return _workspaceHolder.Workspaces;
			}
		}

        /// <summary>
        /// Returns the collection of actions to appear as buttons on the toolbar menu.
        /// </summary>
        public ReadOnlyObservableCollection<IconCommandVm> ToolbarCommands { get; private set; }

        #region Commands
        public void AddQueryWorkspace()
        {
            var workspace = new QueryWorkspaceVm("SAQL" + (++_lastQueryWorkspaceIndex), _assemblies);
            workspace.Commands.CollectionChanged += delegate { RefreshToolbarMenu(); };

            _workspaceHolder.AddNewWorkspace(workspace);
        }

        private void ShowTargetAssemblies()
        {
             RequestOpenAssembliesView(new LoadedAssembliesVm(_assemblies));
        }
        #endregion

        #region View-bound Events

        public event Action<LoadedAssembliesVm> RequestOpenAssembliesView;
        #endregion
    }
}