using Marketo.WPF.MaterialDesign.Commands;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.ViewModels
{
    public class LeadViewModel : BaseViewModel
    {
        public ICommand CreateJobCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public LeadViewModel()
        {
            CreateJobCommand = new CreateJobCommand();
            CancelCommand = new CancelCommand();
        }


    }
}
