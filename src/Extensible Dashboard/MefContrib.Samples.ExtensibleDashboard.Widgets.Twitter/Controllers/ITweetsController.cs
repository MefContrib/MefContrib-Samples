namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Controllers
{
    using System.Collections.Generic;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.ViewModels;

    public interface ITweetsController
    {
        IEnumerable<Tweet> GetTweetsForUser(string userName);
    }
}