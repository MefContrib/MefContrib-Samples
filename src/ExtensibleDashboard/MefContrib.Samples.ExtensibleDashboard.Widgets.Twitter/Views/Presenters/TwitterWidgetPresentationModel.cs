namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Views.Presenters
{
    using System.Collections.ObjectModel;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Controllers;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.ViewModels;

    public class TwitterWidgetPresentationModel
    {
        public ObservableCollection<Tweet> Tweets { get; private set; }

        public TwitterWidgetPresentationModel(ITweetsController tweetsController)
        {
            Tweets = new ObservableCollection<Tweet>();

            var tweets = tweetsController.GetTweetsForUser("@JohnSmith");
            foreach (var tweet in tweets)
            {
                Tweets.Add(tweet);
            }
        }
    }
}