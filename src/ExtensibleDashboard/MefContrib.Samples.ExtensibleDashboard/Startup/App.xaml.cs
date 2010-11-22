using System;
using System.Windows;

namespace MefContrib.Samples.ExtensibleDashboard.Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.Run();
        }
    }
}
