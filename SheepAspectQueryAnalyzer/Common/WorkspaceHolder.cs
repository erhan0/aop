using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;

namespace SheepAspectQueryAnalyzer.Common
{
    public class WorkspaceHolder
    {
        readonly ObservableCollection<WorkspaceVm> _workspaces;

        public WorkspaceHolder()
        {
            _workspaces = new ObservableCollection<WorkspaceVm>();
            _workspaces.CollectionChanged += OnWorkspacesChanged;
            Workspaces = new ReadOnlyObservableCollection<WorkspaceVm>(_workspaces);

            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.CurrentChanged += delegate(object sender, EventArgs e)
                {
                    if (CurrentChanged != null)
                        CurrentChanged(sender, e);
                };
        }

        public void CloseAll()
        {
            _workspaces.Clear();
        }

        public void AddNewWorkspace(WorkspaceVm workspace) 
        {
           _workspaces.Add(workspace);
            SetCurrentWorkspace(workspace);
        }

        public WorkspaceVm CurrentWorkspace
        {
            get
            {
                var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
                if (collectionView == null)
                    return null;
                return collectionView.CurrentItem as WorkspaceVm;
            }
        }

        public ReadOnlyObservableCollection<WorkspaceVm> Workspaces { get; private set;}


        #region Private Methods
        void SetCurrentWorkspace(WorkspaceVm workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }


        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceVm workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceVm workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as WorkspaceVm;
            if (workspace != null)
            {
                workspace.Dispose();
                _workspaces.Remove(workspace);
            }
        }
        #endregion // Private Methods

        #region Events

        public event EventHandler CurrentChanged;
        #endregion
    }
}