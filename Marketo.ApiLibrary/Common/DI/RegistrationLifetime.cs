using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketo.ApiLibrary.Common.DI
{
    public enum RegistrationLifetime
    {
        InstancePerResolve = 0,
        InstancePerThread = 1,
        InstancePerApplication = 2
    }
}
