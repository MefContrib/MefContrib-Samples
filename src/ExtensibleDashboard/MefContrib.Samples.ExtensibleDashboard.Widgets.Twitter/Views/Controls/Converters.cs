namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Views.Controls
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.ViewModels;

    public class DateAndProgramNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tweet = value as Tweet;
            if (tweet != null)
            {
                return string.Format("Send on {0} {1} from {2}.", tweet.Date.ToShortDateString(),
                                     tweet.Date.ToShortTimeString(), tweet.ProgramName);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}