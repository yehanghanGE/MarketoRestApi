using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Common.Logging
{
    public enum LogNotificationLevel
    {
        //
        // Summary:
        //     Debug level.
        Debug = 10,
        //
        // Summary:
        //     Information level.
        Info = 20,
        //
        // Summary:
        //     Warning level.
        Warning = 30,
        //
        // Summary:
        //     Error level.
        Error = 40,
        //
        // Summary:
        //     Fatal error level.
        Fatal = 50,
        //
        // Summary:
        //     No logging.
        None = 60
    }
}
