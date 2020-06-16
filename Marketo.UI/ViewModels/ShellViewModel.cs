using Caliburn.Micro;
using System.Threading;

namespace Marketo.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<DownloadFileViewModel>(), new CancellationToken());
        }
    }
}
