using Marketo.WPF.MaterialDesign.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MouseDown += Window_MouseDown;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
