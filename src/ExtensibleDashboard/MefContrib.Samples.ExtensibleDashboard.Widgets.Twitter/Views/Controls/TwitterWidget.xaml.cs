using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Views.Presenters;

namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Views.Controls
{
    using MefContrib.Samples.ExtensibleDashboard.Contracts;

    /// <summary>
    /// Interaction logic for TwitterWidget.xaml
    /// </summary>
    public partial class TwitterWidget : IWidget
    {
        public TwitterWidget()
        {
            InitializeComponent();
        }

        public TwitterWidgetPresentationModel PresentationModel
        {
            get { return (TwitterWidgetPresentationModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
