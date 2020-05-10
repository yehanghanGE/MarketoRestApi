using MarketoApiLibrary.Common.Model;
using System.Collections.Generic;

namespace MarketoApiLibrary.Common.Services
{
    /// <summary>
    /// Provides functionality to map api models onto the domain entities
    /// </summary>
    public interface IEntityMapperService
    {
        /// <summary>
        /// Get entity from api model
        /// </summary>
        /// <typeparam name="TApiModel">Api model type</typeparam>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="model">Api model</param>
        /// <returns></returns>
        TEntity ReadEntity<TApiModel, TEntity>(TApiModel model)
            where TApiModel : ApiModel
            where TEntity : Entity;

        /// <summary>
        /// Get api model from entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TApiModel">Api model type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        TApiModel ReadApiModel<TEntity, TApiModel>(TEntity entity)
            where TApiModel : ApiModel
            where TEntity : Entity;

        /// <summary>
        /// Get a collection of Entities from a collection of API models
        /// </summary>
        /// <typeparam name="TApiModel">API model type</typeparam>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="models">The collection of API models</param>
        /// <param name="keepNull">Pass True to return null if the collection of API models is null. Otherwise, an empty array will be returned.</param>
        /// <returns></returns>
        TEntity[] ReadEntities<TApiModel, TEntity>(IEnumerable<TApiModel> models, bool keepNull = false)
            where TApiModel : ApiModel
            where TEntity : Entity;
        /// <summary>
        /// Get response model from api model
        /// </summary>
        /// <typeparam name="TApiModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        TResponse ReadResponse<TApiModel, TResponse>(TApiModel model)
            where TApiModel : ApiModel
            where TResponse : ApiModel;
    }
}
