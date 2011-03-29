using System;
using Castle.MicroKernel;
using Castle.Windsor;
using MefContrib.Containers;

namespace MefContrib.Integration.Castle
{
    public class WindsorContainerAdapter : ContainerAdapterBase
    {
        private readonly WindsorContainer _container;

        public WindsorContainerAdapter(WindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
            _container.Kernel.ComponentRegistered += ComponentRegisteredHandler;
        }

        private void ComponentRegisteredHandler(string key, IHandler handler)
        {
            RegisterCastleComponent(handler);
        }

        public override object Resolve(Type type, string name)
        {
            return name == null
                       ? _container.Resolve(type)
                       : _container.Resolve(name, type);
        }

        public override void Initialize()
        {
            var handlers = _container.Kernel.GetAssignableHandlers(typeof (object));
            foreach (var handler in handlers)
            {
                RegisterCastleComponent(handler);
            }
        }

        private void RegisterCastleComponent(IHandler handler)
        {
            var name = handler.ComponentModel.Name;
            var type = handler.Service;

            // By default, Windsor assigns implementation's full name for the key,
            // but for a default key we want to pass null instead
            if (handler.ComponentModel.Implementation.FullName == name)
            {
                name = null;
            }

            OnRegisteringComponent(type, name);
        }
    }
}