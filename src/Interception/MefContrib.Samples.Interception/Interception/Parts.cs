using System;
using System.ComponentModel.Composition;

namespace MefContrib.Samples.Interception
{
    #region Bar

    public interface IBar
    {
        void Foo();
    }

    [Export(typeof(IBar))]
    public class Bar : IBar, IStartable
    {
        public Bar()
        {
            Console.WriteLine("Bar()");
        }

        public bool IsStarted { get; private set; }

        public void Start()
        {
            IsStarted = true;
            Console.WriteLine("Bar.Start()");
        }

        public void Foo()
        {
            Console.WriteLine("Bar.Foo()");
        }
    }

    #endregion
    
    #region Foo

    public interface IFoo
    {
        void Bar();
    }

    [Export(typeof(IFoo))]
    [ExportMetadata("Log", true)]
    public class Foo : IFoo, IStartable
    {
        public Foo()
        {
            Console.WriteLine("Foo()");
        }
        
        public bool IsStarted { get; private set; }

        public void Bar()
        {
            Console.WriteLine("Foo.Bar()");
        }

        public void Start()
        {
            IsStarted = true;
            Console.WriteLine("Foo.Start()");
        }
    }

    #endregion
}