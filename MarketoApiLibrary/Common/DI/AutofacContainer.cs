using Autofac;
using System;
using System.Collections.Generic;
using MarketoApiLibrary.Common.DI.Events;

namespace MarketoApiLibrary.Common.DI
{
    internal interface IAutofacContainer : IMarketoApiContainer
    {
    }

    public class AutofacContainer : IAutofacContainer
    {
        private static IContainer _container;
        private ContainerBuilder _containerBuilder;
        private List<IMarketoApiModule> _moduleCatalog;

        [ThreadStatic]
        private IMarketoApiContainer _threadContainer;
        private IMarketoApiContainer ThreadContainer
        {
            get
            {
                if (_threadContainer == null)
                {
                    _threadContainer = GetThreadContainer();
                }

                return _threadContainer;
            }
        }

        public bool IsInitialized => _container != null;

        public event EventHandler<MarketoApiContainerEventArgs> BeforeRegistrationCompletes;

        public void Initialize()
        {
            _containerBuilder = new ContainerBuilder();
            _moduleCatalog = new List<IMarketoApiModule>();

            RegisterModules();
            InitializeModules();

            var overridableContainer = new OverridableContainer(this);
            this.Raise(BeforeRegistrationCompletes, new MarketoApiContainerEventArgs(overridableContainer));

            _container = _containerBuilder.Build();
        }

        private void RegisterModules()
        {
            _moduleCatalog.Add(new MarketoApiModule());
            _moduleCatalog.Add(new MarketoApiControllerModule());
        }

        private void InitializeModules()
        {
            foreach (var module in _moduleCatalog)
            {
                module.Initialize(this);
            }
        }

        private static IMarketoApiContainer GetThreadContainer()
        {
            return new AutofacThreadContainer(_container);
        }

        public virtual void RegisterType<T, U>(
            RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve) where U : T
        {
            switch (registrationLifetime)
            {
                case RegistrationLifetime.InstancePerResolve:
                    _containerBuilder.RegisterType<U>().As<T>();
                    return;
                case RegistrationLifetime.InstancePerThread:
                    _containerBuilder.RegisterType<U>().As<T>().InstancePerLifetimeScope();
                    return;
                case RegistrationLifetime.InstancePerApplication:
                    _containerBuilder.RegisterType<U>().As<T>().SingleInstance();
                    return;
            }
        }

        public virtual void RegisterGeneric(Type sourceType, Type targetType, RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve)
        {
            switch (registrationLifetime)
            {
                case RegistrationLifetime.InstancePerResolve:
                    _containerBuilder.RegisterGeneric(targetType).As(sourceType);
                    return;
                case RegistrationLifetime.InstancePerThread:
                    _containerBuilder.RegisterGeneric(targetType).As(sourceType).InstancePerLifetimeScope();
                    return;
                case RegistrationLifetime.InstancePerApplication:
                    _containerBuilder.RegisterGeneric(targetType).As(sourceType).SingleInstance();
                    return;
            }
        }

        public virtual void RegisterInstance(Type targetType, object value)
        {
            _containerBuilder.RegisterInstance(value).As(targetType).ExternallyOwned();
        }

        public T Resolve<T>(params IConstructorNamedParameter[] parameters)
        {
            return ThreadContainer.Resolve<T>(parameters);
        }

    }
}
