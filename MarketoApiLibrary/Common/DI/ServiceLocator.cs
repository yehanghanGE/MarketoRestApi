using Ninject;

namespace MarketoApiLibrary.Common.DI
{
    internal interface IServiceLocator
    {
        T Get<T>();
    }

    internal class ServiceLocator
    {
        private static IServiceLocator serviceLocator;

        static ServiceLocator()
        {
            serviceLocator = new DefaultServiceLocator();
        }

        public static IServiceLocator Current
        {
            get
            {
                return serviceLocator;
            }
        }

        private class DefaultServiceLocator : IServiceLocator
        {
            private readonly IKernel kernel;  // Ninject kernel

            public DefaultServiceLocator()
            {
                kernel = new StandardKernel();
            }

            public T Get<T>()
            {
                return kernel.Get<T>();
            }
        }
    }
}
