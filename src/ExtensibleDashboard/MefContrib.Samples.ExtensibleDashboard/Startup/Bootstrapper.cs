namespace MefContrib.Samples.ExtensibleDashboard.Startup
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using MefContrib.Samples.ExtensibleDashboard.Views.Presenters;
    using MefContrib.Hosting.Conventions;

    public class Bootstrapper
    {
        public ShellPresentationModel Main { get; private set; }
        
        public static void Run()
        {
            var locator =
                new PartRegistryLocator(new[] { new ExtensionRegistry() });

            var conventionCatalog = new ConventionCatalog(locator);
            var compositionContainer = new CompositionContainer(conventionCatalog);

            var part = new ConventionPart<Bootstrapper>();
            compositionContainer.ComposeParts(part);

            var bootstrapper = part.Imports.First();
            bootstrapper.Main.Run();
        }
    }
}