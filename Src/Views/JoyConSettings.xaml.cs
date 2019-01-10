using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JoyConsPro.Src.Views
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
