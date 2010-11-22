using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MefContrib.Hosting.Generics;
using MefContrib.Hosting.Interception;
using MefContrib.Hosting.Interception.Configuration;

namespace MefContrib.Samples.Generics
{
    /// <summary>
    /// Shows how to use open-generics support. <see cref="CreateContainer1"/>
    /// and <see cref="CreateContainer2"/> mothods are equivalents.
    /// </summary>
    public class GenericsDemo
    {
        private static CompositionContainer CreateContainer1()
        {
            // Create source catalog, note we are passing the registry part.
            // During the runtime, GenericExportHandler will query this catalog for
            // all types implementing IGenericContractRegistry
            var typeCatalog = new TypeCatalog(typeof(Trampoline), typeof(MyGenericContractRegistry));

            // Create the interception configuration and add support for open generics
            var cfg = new InterceptionConfiguration()
                .AddHandler(new GenericExportHandler());

            // Create the InterceptingCatalog and pass the configuration
            var interceptingCatalog = new InterceptingCatalog(typeCatalog, cfg);

            // Create the container
            return new CompositionContainer(interceptingCatalog);
        }

        private static CompositionContainer CreateContainer2()
        {
            // Create source catalog
            var typeCatalog = new TypeCatalog(typeof(Trampoline));

            // Create catalog which supports open-generics, pass in the registry
            var genericCatalog = new GenericCatalog(new MyGenericContractRegistry());

            // Aggregate the both catalogs
            var aggregateCatalog = new AggregateCatalog(typeCatalog, genericCatalog);

            // Create the container
            return new CompositionContainer(aggregateCatalog);
        }

        public void Run()
        {
            Console.WriteLine("*** Generics Demo ***");

            // Create the container
            var container = CreateContainer2();

            // Get the trampoline object
            var trampoline = container.GetExportedValue<Trampoline>();

            // Test the open generics support
            trampoline.Repository.Save(new Customer());

            try
            {
                // This results in exception being thrown. The user cannot directly query for
                // open-generics type because underneath MEF creates ContractBasedImportDefinition
                // from which it is not possible to determin the open-generics type to for
                // creating closed generic part. This is why Trampoline class is used.
                container.GetExportedValue<IRepository<Customer>>();
            }
            catch
            {
            }
        }

        [Export]
        public class Trampoline
        {
            [Import]
            public IRepository<Customer> Repository { get; set; }
        }
    }
}