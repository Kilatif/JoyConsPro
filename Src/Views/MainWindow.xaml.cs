using System.Windows;
using System.Windows.Controls;
using JoyConsPro.Src.Views;

namespace JoyConsPro.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StatusView.LeftJoyConStatus = JoyConStatus.Connected;
            StatusView.RightJoyConStatus = JoyConStatus.Connected;
            StatusView.IsProConnected = false;
        }
    }
}
