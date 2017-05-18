using System;
using System.Windows.Input;

namespace SheepAspectQueryAnalyzer.Common
{
    /// <summary>
    /// Represents an actionable item displayed by a View.
    /// </summary>
    public class CommandVm : ViewModelBase
    {
        public CommandVm(string displayName, Action<object> execute)
            : this(displayName, new ActionCommand(execute))
        {
        }

        public CommandVm(string displayName, ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            base.DisplayName = displayName;
            this.Command = command;
        }

        public ICommand Command { get; private set; }
    }
}