using System.Windows;
using JoyConsPro.Views;

namespace JoyConsPro.ViewModels
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

    class JoyConSettingsViewModel : DependencyObject
    {
        private const string DefaultJoyConName = "Unknown";

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            "Status", typeof(JoyConStatus), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(JoyConStatus)));

        public JoyConStatus Status
        {
            get => (JoyConStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public static readonly DependencyProperty JoyConNameProperty = DependencyProperty.Register(
            "JoyConName", typeof(string), typeof(JoyConSettingsViewModel), new PropertyMetadata(DefaultJoyConName));

        public string JoyConName
        {
            get => (string)GetValue(JoyConNameProperty);
            set => SetValue(JoyConNameProperty, value);
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type", typeof(JoyConType), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(JoyConType)));

        public JoyConType Type
        {
            get => (JoyConType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty BatteryLevelProperty = DependencyProperty.Register(
            "BatteryLevel", typeof(BatteryLevel), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(BatteryLevel)));

        public BatteryLevel BatteryLevel
        {
            get => (BatteryLevel)GetValue(BatteryLevelProperty);
            set => SetValue(BatteryLevelProperty, value);
        }

        public static readonly DependencyProperty SensetivityLevelProperty = DependencyProperty.Register(
            "SensetivityLevel", typeof(int), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(int)));

        public int SensetivityLevel
        {
            get => (int)GetValue(SensetivityLevelProperty);
            set => SetValue(SensetivityLevelProperty, value);
        }

        public static readonly DependencyProperty SlSrBindTypeProperty = DependencyProperty.Register(
            "SlSrBindType", typeof(SlSrBindType), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(SlSrBindType)));

        public SlSrBindType SlSrBindType
        {
            get => (SlSrBindType)GetValue(SlSrBindTypeProperty);
            set => SetValue(SlSrBindTypeProperty, value);
        }

        public static readonly DependencyProperty SlValueProperty = DependencyProperty.Register(
            "SlValue", typeof(int), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(int)));

        public int SlValue
        {
            get => (int)GetValue(SlValueProperty);
            set => SetValue(SlValueProperty, value);
        }

        public static readonly DependencyProperty SrValueProperty = DependencyProperty.Register(
            "SrValue", typeof(int), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(int)));

        public int SrValue
        {
            get => (int)GetValue(SrValueProperty);
            set => SetValue(SrValueProperty, value);
        }

        public static readonly DependencyProperty IsSlHoldEnablingProperty = DependencyProperty.Register(
            "IsSlHoldEnabling", typeof(bool), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(bool)));

        public bool IsSlHoldEnabling
        {
            get => (bool)GetValue(IsSlHoldEnablingProperty);
            set => SetValue(IsSlHoldEnablingProperty, value);
        }

        public static readonly DependencyProperty IsSrHoldEnablingProperty = DependencyProperty.Register(
            "IsSrHoldEnabling", typeof(bool), typeof(JoyConSettingsViewModel), new PropertyMetadata(default(bool)));

        public bool IsSrHoldEnabling
        {
            get => (bool)GetValue(IsSrHoldEnablingProperty);
            set => SetValue(IsSrHoldEnablingProperty, value);
        }
    }
}
