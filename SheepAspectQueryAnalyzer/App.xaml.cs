using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using SheepAspectQueryAnalyzer.View;
using SheepAspectQueryAnalyzer.ViewModel;

namespace SheepAspectQueryAnalyzer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            // Bind culture with OS culture
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialise infrastructure, and inject to ViewModel
            var window = new MainWindow(new MainWindowVm());

            window.Show();
        }
    }

}
