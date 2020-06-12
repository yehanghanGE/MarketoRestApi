using Marketo.WPF.MaterialDesign.Commands;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.ViewModels
{
	public interface IMainViewModel
	{
		BaseViewModel CurrentViewModel { get; set; }
		ICommand UpdateCurrentViewModelCommand { get; }
	}

	public class MainViewModel : BaseViewModel, IMainViewModel
	{
		private BaseViewModel _currentViewModel;

		public BaseViewModel CurrentViewModel
		{
			get { return _currentViewModel; }
			set
			{
				_currentViewModel = value;
				OnPropertyChanged();
			}
		}

		public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
	}
}
