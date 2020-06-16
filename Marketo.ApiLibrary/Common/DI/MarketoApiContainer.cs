using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketo.ApiLibrary.Common.DI
{
    public static class MarketoApiContainer
    {
        private static readonly IMarketoApiContainer _container;

        static MarketoApiContainer()
        {
            _container = new AutofacContainer();
        }

        public static T Resolve<T>()
        {
            if (!_container.IsInitialized)
            {
                _container.Initialize();
            }

            return _container.Resolve<T>();
        }
    }
}
