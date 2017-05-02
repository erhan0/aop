using System;
using System.Windows.Input;

namespace SheepAspectQueryAnalyzer.Common
{
    /// <summary>
    /// A command whose sole purpose is to 
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class ActionCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;        

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates an ActionCommand that can always execute.
        /// </summary>
        /// <param name="execute">Specify action delegate to be invoked this command is executed<</param>
        public ActionCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates an ActionCommand.
        /// </summary>
        /// <param name="execute">Specify action delegate to be invoked this command is executed</param>
        /// <param name="canExecute">Specify delegate to that governs CanExecute logic</param>
        public ActionCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;           
        }

        #endregion // Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }
}