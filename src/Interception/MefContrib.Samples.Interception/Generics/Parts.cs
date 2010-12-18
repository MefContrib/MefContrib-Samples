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

    public interface IRepository<T>
    {
        T Get(int id);

        void Save(T instance);
    }

    /// <summary>
    /// Wow! I can export a class with an open generic contract type!
    /// </summary>
    [Export(typeof(IRepository<>))]
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

    /// <summary>
    /// Fake customer.
    /// </summary>
    public class Customer { }

    /// <summary>
    /// Consumer of the generic <see cref="IRepository{T}"/> interface.
    /// Although it is imported as a closed generic, it is exported as open generic!
    /// </summary>
    [Export]
    public class CustomerViewModel
    {
        [Import]
        public IRepository<Customer> Repository { get; set; }
    }
}