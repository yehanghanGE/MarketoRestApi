using System;
using System.Net;

namespace Marketo.ApiLibrary.Common.Http.Services
{
    public static class ServicePointManagerUtility
    {
        public static ServicePoint FindServicePoint(Uri address)
        {
            return ServicePointManager.FindServicePoint(address);
        }

        public static int DnsRefreshTimeout
        {
            get { return ServicePointManager.DnsRefreshTimeout; }
            set { ServicePointManager.DnsRefreshTimeout = value; }
        }
    }
}
