namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Controllers
{
    using System;
    using System.Collections.Generic;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.ViewModels;

    public class TweetsController : ITweetsController
    {
        public IEnumerable<Tweet> GetTweetsForUser(string userName)
        {
            yield return new Tweet
            {
                UserName = userName,
                Date = new DateTime(2010, 4, 1, 20, 23, 11),
                ProgramName = "Extensible Dashboard",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam in dolor massa, vel suscipit dui. Donec hendrerit dolor sit amet magna congue egestas."
            };

            yield return new Tweet
            {
                UserName = userName,
                Date = new DateTime(2010, 4, 1, 20, 33, 11),
                ProgramName = "Extensible Dashboard",
                Message = "Fusce at lectus quis tortor ultrices hendrerit id in sem. Quisque sed enim magna, at pharetra magna. Aliquam erat volutpat. In convallis lobortis dui sit amet fermentum."
            };

            yield return new Tweet
            {
                UserName = userName,
                Date = new DateTime(2010, 4, 1, 20, 35, 11),
                ProgramName = "Extensible Dashboard",
                Message = "Phasellus sodales, tellus sed elementum hendrerit, enim augue hendrerit odio, quis vulputate est arcu id metus. Nulla porttitor molestie nunc, et porttitor tortor sodales nec."
            };

            yield return new Tweet
            {
                UserName = userName,
                Date = new DateTime(2010, 4, 1, 21, 23, 11),
                ProgramName = "Extensible Dashboard",
                Message = "Aliquam pretium condimentum augue id iaculis. Nam pellentesque, metus vel venenatis accumsan, nisl augue tincidunt lectus, vel ornare lectus felis eget mauris."
            };
        }
    }
}