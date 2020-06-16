namespace Marketo.ApiLibrary.Common.DI
{
    public class MarketoApiModule : IMarketoApiModule
    {
        public void Initialize(IMarketoApiContainer container)
        {
            // Register a singleton of the container, do not use InstancePerApplication
            container.RegisterInstance(typeof(IMarketoApiContainer), container);
        }
    }
}