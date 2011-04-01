namespace MefContrib.Samples.ExtensibleDashboard.Startup
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using MefContrib.Hosting.Conventions;
    using MefContrib.Hosting.Conventions.Configuration;
    using MefContrib.Samples.ExtensibleDashboard.Views.Presenters;

    public class Bootstrapper
    {
        public ShellPresentationModel Main { get; private set; }
        
        public static void Run()
        {
            var locator =
                new PartRegistryLocator(new IPartRegistry<DefaultConventionContractService>[]
                {
                    new ConfigurationPartRegistry("mef.configuration"), new ExtensionRegistry()
                });

            var conventionCatalog = new ConventionCatalog(locator);
            var compositionContainer = new CompositionContainer(conventionCatalog);

            var part = new ConventionPart<Bootstrapper>();
            compositionContainer.ComposeParts(part);

            var bootstrapper = part.Imports.First();
            bootstrapper.Main.Run();
        }
    }
}