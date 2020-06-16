namespace Marketo.ApiLibrary.Common.DI
{
    /// <summary>
    ///  Module used to initialize MarketoApi dependency injection
    /// </summary>
    public interface IMarketoApiModule
    {
        /// <summary>
        /// Initialize the module registration.
        /// </summary>
        void Initialize(IMarketoApiContainer container);
    }
}
