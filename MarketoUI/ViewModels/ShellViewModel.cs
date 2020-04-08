using Caliburn.Micro;

namespace MarketoUI.ViewModels
{
    public class ShellViewModel:Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(IoC.Get<DownloadFileViewModel>());
        }
    }
}
