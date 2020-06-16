using Marketo.WPF.MaterialDesign.Commands;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.ViewModels
{
	public class FileViewModel : BaseViewModel
	{
		private string _folderId;

		public string FolderId
		{
			get => _folderId;
			set
			{
				_folderId = value;
				OnPropertyChanged();
			}
		}

		private string _savePath;
		public string SavePath
		{
			get => _savePath;
			set
			{
				_savePath = value;
				OnPropertyChanged();
			}
		}

		public ICommand StartCommand { get; set; }
		public ICommand CancelCommand { get; set; }


		public FileViewModel()
		{
			StartCommand = new StartCommand();
			CancelCommand = new CancelCommand();
		}
	}
}
