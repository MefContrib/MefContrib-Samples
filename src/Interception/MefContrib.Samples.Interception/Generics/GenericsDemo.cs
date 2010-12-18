using System;
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
            var typeCatalog = new TypeCatalog(typeof(CustomerViewModel), typeof(MyGenericContractRegistry));

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
            var typeCatalog = new TypeCatalog(typeof(CustomerViewModel));

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

            // Get the model object
            var model = container.GetExportedValue<CustomerViewModel>();

            // Test the open generics support
            model.Repository.Save(new Customer());

            try
            {
                // This results in exception being thrown. The user cannot directly query for
                // open-generics type because underneath MEF creates ContractBasedImportDefinition
                // from which it is not possible to determin the open-generics type for
                // creating closed generic part.
                container.GetExportedValue<IRepository<Customer>>();
            }
            catch
            {
            }
        }
    }
}