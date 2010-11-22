namespace MefContrib.Samples.ExtensibleDashboard.Views
{
    using MefContrib.Samples.ExtensibleDashboard.Views.Presenters;

    public interface IShellView
    {
        ShellPresentationModel PresentationModel { get; set; }

        void Show();
    }
}