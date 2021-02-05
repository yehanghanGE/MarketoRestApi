using System;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.Commands
{
    internal class CreateJobCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //BulkExportLeads.CreateExportLeadJob();
        }

        public event EventHandler CanExecuteChanged;
    }
}