using System;
using System.Windows.Input;
using System.Windows.Media;
using SheepAspectQueryAnalyzer.Properties;

namespace SheepAspectQueryAnalyzer.Common
{
    public class IconCommandVm: CommandVm
    {
        public IconCommandVm(string displayName, ImageSource iconImageSource, Action<object> execute) : base(displayName, execute)
        {
            IconImageSource = iconImageSource;
        }

        public IconCommandVm(string displayName, ImageSource iconImageSource, ICommand command)
            : base(displayName, command)
        {
            IconImageSource = iconImageSource;
        }

        public ImageSource IconImageSource { get; private set; }
    }
}