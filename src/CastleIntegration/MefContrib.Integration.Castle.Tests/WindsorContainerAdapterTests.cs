using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MefContrib.Containers;
using NUnit.Framework;

namespace MefContrib.Integration.Castle.Tests
{
    [TestFixture]
    public class WindsorContainerAdapterTests
    {
        [Test]
        public void Mef_can_resolve_single_component()
        {
            var windsorContainer = new WindsorContainer();
            var provider = new ContainerExportProvider(new WindsorContainerAdapter(windsorContainer));
            var compositionContainer = new CompositionContainer(provider);

            // Setup Castle Windsor
            windsorContainer.Register(Component.For<IFoo>().ImplementedBy<Foo>());

            var fooExport = compositionContainer.GetExport<IFoo>();
            Assert.That(fooExport, Is.Not.Null);
            Assert.That(fooExport.Value.GetType(), Is.EqualTo(typeof(Foo)));
        }

        [Test]
        public void Mef_can_resolve_single_component_registered_by_name()
        {
            var windsorContainer = new WindsorContainer();
            var provider = new ContainerExportProvider(new WindsorContainerAdapter(windsorContainer));
            var compositionContainer = new CompositionContainer(provider);

            // Setup Castle Windsor
            windsorContainer.Register(Component.For<IFoo>().ImplementedBy<Foo2>().Named("foo2"));

            var fooExport = compositionContainer.GetExport<IFoo>("foo2");
            Assert.That(fooExport, Is.Not.Null);
            Assert.That(fooExport.Value.GetType(), Is.EqualTo(typeof(Foo2)));
        }

        [Test]
        public void Mef_can_resolve_all_components()
        {
            var windsorContainer = new WindsorContainer();
            var provider = new ContainerExportProvider(new WindsorContainerAdapter(windsorContainer));
            var compositionContainer = new CompositionContainer(provider);

            // Setup Castle Windsor
            windsorContainer.Register(Component.For<IFoo>().ImplementedBy<Foo>());
            windsorContainer.Register(Component.For<IFoo>().ImplementedBy<Foo2>().Named("foo2"));

            var fooExports = compositionContainer.GetExports<IFoo>();
            Assert.That(fooExports, Is.Not.Null);
            Assert.That(fooExports.Select(t => t.Value).OfType<Foo>().Count(), Is.EqualTo(1));
            Assert.That(fooExports.Select(t => t.Value).OfType<Foo2>().Count(), Is.EqualTo(1));
        }

        [Test]
        public void Mef_can_resolve_single_component_even_when_registered_before_creating_adapter()
        {
            var windsorContainer = new WindsorContainer();
            
            // Setup Castle Windsor
            windsorContainer.Register(Component.For<IFoo>().ImplementedBy<Foo>());

            var provider = new ContainerExportProvider(new WindsorContainerAdapter(windsorContainer));
            var compositionContainer = new CompositionContainer(provider);

            // Test
            var fooExport = compositionContainer.GetExport<IFoo>();
            Assert.That(fooExport, Is.Not.Null);
            Assert.That(fooExport.Value.GetType(), Is.EqualTo(typeof(Foo)));
        }
    }
}