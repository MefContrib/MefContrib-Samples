namespace MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter
{
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Controllers;
    using MefContrib.Samples.ExtensibleDashboard.Widgets.Twitter.Views.Presenters;
    using MefContrib.Hosting.Conventions.Configuration;

    public class TwitterRegistry : PartRegistry
    {
        public TwitterRegistry()
        {
            Scan(x => x.Assembly(typeof(TwitterRegistry).Assembly));

            Part()
                .ForTypesAssignableFrom<TwitterWidgetPresentationModel>()
                .ExportTypeAs<TwitterWidgetPresentationModel>()
                .ImportConstructor()
                .MakeShared();

            Part()
                .ForTypesAssignableFrom<ITweetsController>()
                .ExportTypeAs<ITweetsController>()
                .MakeShared();
        }
    }
}