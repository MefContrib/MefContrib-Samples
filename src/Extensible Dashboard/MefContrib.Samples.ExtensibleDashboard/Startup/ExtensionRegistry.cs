namespace MefContrib.Samples.ExtensibleDashboard.Startup
{
    using System;
    using System.Reflection;
    using MefContrib.Samples.ExtensibleDashboard.Contracts;
    using MefContrib.Samples.ExtensibleDashboard.Views;
    using MefContrib.Hosting.Conventions.Configuration;

    public class ExtensionRegistry : PartRegistry
    {
        public ExtensionRegistry()
        {
            Scan(x => {
                x.Assembly(Assembly.GetExecutingAssembly());
                x.Directory(Environment.CurrentDirectory);
            });

            Part()
                .ForTypesWithName("Bootstrapper")
                .MakeShared()
                .ExportType()
                .Imports(x => x.Import().Members(m => new[] {m.GetProperty("Main")}) );

            Part()
                .ForTypesWithName("ShellPresentationModel")
                .MakeShared()
                .ExportType()
                .Imports(x => {
                    x.Import().Members(m => new[] { m.GetProperty("View") });
                    x.Import().Members(m => new[] { m.GetProperty("Widgets") }).ContractType<IWidget>();
                });

            Part()
                .ForTypesWithName("ShellWindow")
                .ExportTypeAs<IShellView>()
                .MakeShared();

            Part()
                .ForTypesAssignableFrom<IWidget>()
                .ExportTypeAs<IWidget>()
                .Imports(x => x.Import().Members(m => new[] { m.GetProperty("PresentationModel") } ));

            Part()
                .ForTypesWhereNamespaceContains("StockTicker")
                .ExportType();
        }
    }
}