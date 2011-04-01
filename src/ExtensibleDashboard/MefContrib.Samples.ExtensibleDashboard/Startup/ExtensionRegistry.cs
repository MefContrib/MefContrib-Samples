namespace MefContrib.Samples.ExtensibleDashboard.Startup
{
    using System;
    using System.Reflection;
    using MefContrib.Hosting.Conventions.Configuration;
    using MefContrib.Samples.ExtensibleDashboard.Contracts;
    using MefContrib.Samples.ExtensibleDashboard.Views;
    using MefContrib.Samples.ExtensibleDashboard.Views.Presenters;
    using MefContrib.Samples.ExtensibleDashboard.Views.Windows;

    public class ExtensionRegistry : PartRegistry
    {
        public ExtensionRegistry()
        {
            Scan(x =>
            {
                x.Assembly(Assembly.GetExecutingAssembly());
                x.Directory(Environment.CurrentDirectory);
            });

            // Bootstrapper part is defined in the App.config file

            Part<ShellPresentationModel>()
                .ImportMember(t => t.View)
                .MakeShared()
                .Export()
                .Imports(x =>
                {
                    x.Import<ShellPresentationModel>().Member(m => m.Widgets).ContractType<IWidget>();
                });

            Part<ShellWindow>()
                .ExportAs<IShellView>()
                .MakeShared();

            Part()
                .ForTypesAssignableFrom<IWidget>()
                .ExportAs<IWidget>()
                .ImportProperty("PresentationModel");

            Part()
                .ForTypesWhereNamespaceContains("StockTicker")
                .Export();
        }
    }
}