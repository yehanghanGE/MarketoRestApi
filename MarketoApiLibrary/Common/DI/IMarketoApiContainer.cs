using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Common.DI
{
    public interface IMarketoApiContainer
    {
        bool IsInitialized { get; }
        //event EventHandler<MarketoApiContainerEventArgs> BeforeRegistrationCompletes;

        void Initialize();

        void RegisterType<T, U>(RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve) where U : T;
        void RegisterGeneric(Type sourceType, Type targetType, RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve);
        void RegisterInstance(Type T, object value);
        void RegisterType<T>(RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve);

        T Resolve<T>(params IConstructorNamedParameter[] parameters);
    }
}
