namespace MefContrib.Samples.ExtensibleDashboard.Views.Windows
{
    using MefContrib.Samples.ExtensibleDashboard.Views.Presenters;

    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        public ShellPresentationModel PresentationModel
        {
            get { return (ShellPresentationModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
