using System;
using MefContrib.Samples.Filter;
using MefContrib.Samples.Generics;
using MefContrib.Samples.Interception;

namespace MefContrib.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new GenericsDemo().Run();

            new FilteringDemo().Run();
            
            new InterceptionDemo().Run();
        }
    }
}
