using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Services
{
    class EntityMapperService:IEntityMapperService
    {
        public TEntity ReadEntity<TApiModel, TEntity>(TApiModel model) where TApiModel : ApiModel where TEntity : Entity
        {
            throw new NotImplementedException();
        }
        
        public TApiModel ReadApiModel<TEntity, TApiModel>(TEntity entity) where TEntity : Entity where TApiModel : ApiModel
        {
            throw new NotImplementedException();
        }

        public TEntity[] ReadEntities<TApiModel, TEntity>(IEnumerable<TApiModel> models, bool keepNull = false) where TApiModel : ApiModel where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public TResponse ReadResponse<TApiModel, TResponse>(TApiModel model) where TApiModel : ApiModel where TResponse : ApiModel
        {
            throw new NotImplementedException();
        }

    }
}
