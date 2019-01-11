using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace JoyConsPro.Views
{
    /// <summary>
    /// Interaction logic for JoyConSettings.xaml
    /// </summary>
    public partial class JoyConSettings : UserControl
    {
        public JoyConSettings()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxName.Focusable = false;
        }

        private void TextBoxName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBoxName.Focusable = true;
            TextBoxName.Focus();
            TextBoxName.Background = new SolidColorBrush(Colors.White);
        }

        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxName.Focusable = false;
            TextBoxName.Background = null;
            ChangeName(TextBoxName.Text);
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBoxName.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                Keyboard.ClearFocus();
            }
        }

        private void ChangeName(string newName)
        {

        }
    }
}
