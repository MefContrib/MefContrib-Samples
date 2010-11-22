using System;
using System.ComponentModel.Composition;
using MefContrib.Hosting.Generics;

namespace MefContrib.Samples.Generics
{
    [Export(typeof(IGenericContractRegistry))]
    public class MyGenericContractRegistry : GenericContractRegistryBase
    {
        protected override void Initialize()
        {
            Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }

    [InheritedExport]
    public interface IRepository<T>
    {
        T Get(int id);

        void Save(T instance);
    }

    /// <summary>
    /// To make <see cref="Repository{T}"/> type MEF discoverable, it has to be exported
    /// using the <see cref="InheritedExportAttribute"/> attribute!!!
    /// </summary>
    [InheritedExport]
    public class Repository<T> : IRepository<T> where T : new()
    {
        public T Get(int id)
        {
            return new T();
        }

        public void Save(T instance)
        {
            Console.WriteLine("Saving {0} instance.", instance.GetType().Name);
        }
    }

    public class Customer { }
}