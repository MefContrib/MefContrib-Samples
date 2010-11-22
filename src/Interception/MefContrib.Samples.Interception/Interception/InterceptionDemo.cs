using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using MefContrib.Hosting.Interception;
using MefContrib.Hosting.Interception.Castle;
using MefContrib.Hosting.Interception.Configuration;

namespace MefContrib.Samples.Interception
{
    public class InterceptionDemo
    {
        public void Run()
        {
            Console.WriteLine("\n*** Interception Demo ***");

            // Create source catalog
            var catalog = new TypeCatalog(typeof(Bar), typeof(Foo));

            // Create interception configuration
            var cfg = new InterceptionConfiguration()

                // Add catalog wide startable interceptor
                .AddInterceptor(new StartableStrategy())

                /*
                .AddInterceptionCriteria(
                    new LogInterceptionCriteria(
                        new DynamicProxyInterceptor(
                            new LoggingInterceptor())))
                */

                // Add Castle DynamicProxy based logging interceptor for parts
                // which want to be logged, does exactly the same as the above code
                .AddInterceptionCriteria(
                    new PredicateInterceptionCriteria(

                        // Apply the interceptor only to parts which contain
                        // Log export metadata which equals to true
                        new DynamicProxyInterceptor(new LoggingInterceptor()), def =>
                            def.ExportDefinitions.First().Metadata.ContainsKey("Log") &&
                            def.ExportDefinitions.First().Metadata["Log"].Equals(true)));

            // Create the InterceptingCatalog with above configuration
            var interceptingCatalog = new InterceptingCatalog(catalog, cfg);
            
            // Create the container
            var container = new CompositionContainer(interceptingCatalog);

            // Bar part will be intercepted only by the startable strategy
            var barPart = container.GetExportedValue<IBar>();
            barPart.Foo();

            // Foo part will be intercepted by both startable and logging strategies
            var fooPart = container.GetExportedValue<IFoo>();
            fooPart.Bar();
        }
    }
}