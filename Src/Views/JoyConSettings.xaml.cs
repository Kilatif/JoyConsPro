using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace JoyConsPro.Views
{
    public enum JoyConType
    {
        Left, Right
    }

    public enum BatteryLevel
    {
        Empty, Critical, Low, Medium, Full
    }

    public enum SlSrBindType
    {
        Default,
        SensLevelChangePlusMinus,
        SensLevelChangeMinusPlus,
        SensLevelValueGyroOnOff
    }

    public class Test : DependencyObject
    {
        public static readonly DependencyProperty TestValueProperty = DependencyProperty.Register(
            "TestValue", typeof(string), typeof(Test), new PropertyMetadata(default(string)));

        public string TestValue
        {
            get => (string) GetValue(TestValueProperty);
            set => SetValue(TestValueProperty, value);
        }
    }

    /// <summary>
    /// Interaction logic for JoyConSettings.xaml
    /// </summary>
    public partial class JoyConSettings : UserControl
    {
        private const string DefaultJoyConName = "Unknown";

        #region Dependency Properties

        public static readonly DependencyProperty JoyConNameProperty = DependencyProperty.Register(
            "JoyConName", typeof(string), typeof(JoyConSettings), new PropertyMetadata(DefaultJoyConName));

        public string JoyConName
        {
            get => (string) GetValue(JoyConNameProperty);
            set => SetValue(JoyConNameProperty, value);
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type", typeof(JoyConType), typeof(JoyConSettings), new PropertyMetadata(default(JoyConType)));

        public JoyConType Type
        {
            get => (JoyConType) GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty BatteryLevelProperty = DependencyProperty.Register(
            "BatteryLevel", typeof(BatteryLevel), typeof(JoyConSettings), new PropertyMetadata(default(BatteryLevel)));

        public BatteryLevel BatteryLevel
        {
            get => (BatteryLevel) GetValue(BatteryLevelProperty);
            set => SetValue(BatteryLevelProperty, value);
        }

        public static readonly DependencyProperty SlSrBindTypeProperty = DependencyProperty.Register(
            "SlSrBindType", typeof(SlSrBindType), typeof(JoyConSettings), new PropertyMetadata(default(SlSrBindType)));

        public SlSrBindType SlSrBindType
        {
            get => (SlSrBindType) GetValue(SlSrBindTypeProperty);
            set => SetValue(SlSrBindTypeProperty, value);
        }

        public static readonly DependencyProperty SlValueProperty = DependencyProperty.Register(
            "SlValue", typeof(int), typeof(JoyConSettings), new PropertyMetadata(default(int)));

        public int SlValue
        {
            get => (int) GetValue(SlValueProperty);
            set => SetValue(SlValueProperty, value);
        }

        public static readonly DependencyProperty SrValueProperty = DependencyProperty.Register(
            "SrValue", typeof(int), typeof(JoyConSettings), new PropertyMetadata(default(int)));

        public int SrValue
        {
            get => (int) GetValue(SrValueProperty);
            set => SetValue(SrValueProperty, value);
        }

        public static readonly DependencyProperty IsSlHoldEnablingProperty = DependencyProperty.Register(
            "IsSlHoldEnabling", typeof(bool), typeof(JoyConSettings), new PropertyMetadata(default(bool)));

        public bool IsSlHoldEnabling
        {
            get => (bool) GetValue(IsSlHoldEnablingProperty);
            set => SetValue(IsSlHoldEnablingProperty, value);
        }

        public static readonly DependencyProperty IsSrHoldEnablingProperty = DependencyProperty.Register(
            "IsSrHoldEnabling", typeof(bool), typeof(JoyConSettings), new PropertyMetadata(default(bool)));

        public bool IsSrHoldEnabling
        {
            get => (bool) GetValue(IsSrHoldEnablingProperty);
            set => SetValue(IsSrHoldEnablingProperty, value);
        }

        #endregion

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
