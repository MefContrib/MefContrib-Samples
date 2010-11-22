using System;
using MefContrib.Hosting.Interception;

namespace MefContrib.Samples.Interception
{
    public class StartableStrategy : IExportedValueInterceptor
    {
        public object Intercept(object value)
        {
            var startable = value as IStartable;
            if (startable != null)
            {
                startable.Start();
            }

            return value;
        }
    }
}