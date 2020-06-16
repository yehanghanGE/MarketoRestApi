using System;

namespace Marketo.ApiLibrary.Common.DI
{
    public class MarketoApiContainerEventArgs : EventArgs
    {
        public MarketoApiContainerEventArgs(IMarketoApiContainer container)
        {
            MarketoApiContainer = container;
        }

        public IMarketoApiContainer MarketoApiContainer { get; private set; }
    }
}