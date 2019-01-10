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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //StatusView.LeftJoyConStatus = JoyConStatus.Connected;
            //StatusView.RightJoyConStatus = JoyConStatus.Unlinked;
            //StatusView.IsProConnected = false;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //StatusView.LeftJoyConStatus = JoyConStatus.Disconnected;
            //StatusView.RightJoyConStatus = JoyConStatus.Connected;
            //StatusView.IsProConnected = true;
        }

        private void MenuItemFind_Click(object sender, RoutedEventArgs e)
        {
            //StatusView.IsProConnected = true;
            //StatusView.IsProConnected = false;
        }
    }
}
