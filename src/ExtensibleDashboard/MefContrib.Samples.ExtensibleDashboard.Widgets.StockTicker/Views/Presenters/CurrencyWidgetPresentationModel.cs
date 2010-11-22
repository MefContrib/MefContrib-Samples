namespace MefContrib.Samples.ExtensibleDashboard.Widgets.StockTicker.Views.Presenters
{
    using System.Collections.ObjectModel;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.StockTicker.ViewModels;

    public class CurrencyWidgetPresentationModel
    {
        public ObservableCollection<Currency> CurrencyCollection { get; private set; }

        public CurrencyWidgetPresentationModel()
        {
            CurrencyCollection = 
                new ObservableCollection<Currency>
                {
                    new Currency { Symbol = "EUR", BuyPrice = 4.00m, SellPrice = 4.12m },
                    new Currency { Symbol = "USD", BuyPrice = 3.21m, SellPrice = 3.45m },
                    new Currency { Symbol = "CHF", BuyPrice = 2.85m, SellPrice = 2.91m },
                    new Currency { Symbol = "GBP", BuyPrice = 4.66m, SellPrice = 4.73m }
                };
        }
    }
}