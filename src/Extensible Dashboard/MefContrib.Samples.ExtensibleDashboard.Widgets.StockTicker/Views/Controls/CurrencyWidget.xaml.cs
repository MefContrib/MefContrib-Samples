namespace MefContrib.Samples.ExtensibleDashboard.Widgets.StockTicker.Views.Controls
{
    using MefContrib.Samples.ExtensibleDashboard.Contracts;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.StockTicker.Views.Presenters;

    /// <summary>
    /// Interaction logic for CurrencyWidget.xaml
    /// </summary>
    public partial class CurrencyWidget : IWidget
    {
        public CurrencyWidget()
        {
            InitializeComponent();
        }

        public CurrencyWidgetPresentationModel PresentationModel
        {
            get { return (CurrencyWidgetPresentationModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
