using System;
using Castle.DynamicProxy;

namespace MefContrib.Samples.Interception
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("--- LOG: About to invoke [{0}] on [{1}] ---",
                invocation.Method.Name,
                invocation.InvocationTarget.GetType().Name);

            // Invoke the intercepted method
            invocation.Proceed();
            
            Console.WriteLine("--- LOG: Invoked [{0}] ---", invocation.Method.Name);
        }
    }
}