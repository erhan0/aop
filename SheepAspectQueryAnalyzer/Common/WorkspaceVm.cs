using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SheepAspectQueryAnalyzer.Common
{
    /// <summary>
    /// This ViewModelBase subclass requests to be removed 
    /// from the UI when its CloseCommand executes.
    /// This class is abstract.
    /// </summary>
    public abstract class WorkspaceVm : ViewModelBase
    {
        #region Fields

        ICommand _closeCommand;

        #endregion // Fields

        #region Constructor

        protected WorkspaceVm()
        {
            Commands = new ObservableCollection<CommandVm>();
        }

        #endregion // Constructor

        #region Commands

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new ActionCommand(x => OnRequestClose())); }
        }

        #endregion // CloseCommand

        #region Properties
        public ObservableCollection<CommandVm> Commands { get; private set; }
        #endregion

        #region Events

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion // RequestClose [event]
    }
}