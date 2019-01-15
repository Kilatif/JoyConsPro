using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace JoyConsPro.Views
{
    /// <summary>
    /// Interaction logic for JoyConSettings.xaml
    /// </summary>
    public partial class JoyConSettingsView : UserControl
    {
        public JoyConSettingsView()
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
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBoxName.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                Keyboard.ClearFocus();
            }
        }
    }
}
