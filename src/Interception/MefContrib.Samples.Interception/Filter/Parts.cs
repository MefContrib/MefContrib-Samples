using System;
using System.ComponentModel.Composition;

namespace MefContrib.Samples.Filter
{
    public interface ISharedPart { }

    [Export(typeof(ISharedPart))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SharedPart : ISharedPart, IDisposable
    {
        public SharedPart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SharedPart()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SharedPart.Dispose()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public interface INonSharedPart { }

    [Export(typeof(INonSharedPart))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NonSharedPart : INonSharedPart, IDisposable
    {
        [Import]
        public ISharedPart Part { get; set; }

        public NonSharedPart()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NonSharedPart()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NonSharedPart.Dispose()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public interface ISharedPartPerRequest { }

    /// <summary>
    /// This part is used to show how to build custom per-XYZ behavior.
    /// Here the part demonstrates per-request bahavior.
    /// </summary>
    [Export(typeof(ISharedPartPerRequest))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [PartMetadata("PerRequest", true)]
    public class SharedPartPerRequest : ISharedPartPerRequest, IDisposable
    {
        public SharedPartPerRequest()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SharedPartPerRequest()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SharedPartPerRequest.Dispose()");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}