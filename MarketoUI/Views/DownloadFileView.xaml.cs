using System.Windows.Controls;

namespace MarketoUI.Views
{
    /// <summary>
    /// Interaction logic for DownloadFileView.xaml
    /// </summary>
    public partial class DownloadFileView : UserControl
    {
        public DownloadFileView()
        {
            InitializeComponent();
        }

        private void TextBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            SavePath.Text = dialog.SelectedPath;
        }
    }
}
