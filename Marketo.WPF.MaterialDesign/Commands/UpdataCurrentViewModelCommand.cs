using Marketo.WPF.MaterialDesign.Models;
using Marketo.WPF.MaterialDesign.ViewModels;
using System;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private IMainViewModel _mainViewModel;

        public UpdateCurrentViewModelCommand(IMainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is ViewType)) return;
            var viewType = (ViewType)parameter;

            switch (viewType)
            {
                case ViewType.Home:
                    _mainViewModel.CurrentViewModel = new HomeViewModel();
                    break;
                case ViewType.Folder:
                    _mainViewModel.CurrentViewModel = new FolderViewModel();
                    break;
            }
        }
    }
}
