using System;
using Microsoft.AspNet.Mvc;
using SimpleInjector;
using System.Diagnostics;

namespace XprsIo.API
{
    internal class SimpleInjectorControllerActivator : IControllerActivator
    {
        private Container _container;

        public SimpleInjectorControllerActivator(Container _container)
        {
            this._container = _container;
        }

        [DebuggerStepThrough]
        public object Create(ActionContext context, Type controllerType)
        {
            return _container.GetInstance(controllerType);
        }
    }
}