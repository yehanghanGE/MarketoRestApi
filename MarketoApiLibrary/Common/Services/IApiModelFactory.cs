using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Services
{
    /// <summary>
    /// Provides methods for working with api models
    /// </summary>
    public interface IApiModelFactory
    {
        /// <summary>
        /// Get api model objects of a specified type
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <returns></returns>
        T GetApiModel<T>() where T : ApiModel;
    }
}
