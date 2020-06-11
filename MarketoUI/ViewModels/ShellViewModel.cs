using Caliburn.Micro;
using System.Threading;

namespace MarketoUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<DownloadFileViewModel>(), new CancellationToken());
        }
    }
}
