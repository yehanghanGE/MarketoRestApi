using System;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Services
{
    public class ApiModelFactory : IApiModelFactory
    {
        public T GetApiModel<T>() where T : ApiModel
        {
            throw new NotImplementedException();
        }
    }
}
