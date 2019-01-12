using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace JoyConsPro.Views
{
    public enum JoyConStatus
    {
        Unlinked,
        Disconnected,
        Connected
    }

    /// <summary>
    /// Interaction logic for ControllersStatusView.xaml
    /// </summary>
    public partial class ControllersStatusView : UserControl
    {
        private static readonly Color DefaultJoyConBodyColor = Color.FromRgb(122, 122, 122);

        public static readonly DependencyProperty IsProConnectedProperty = DependencyProperty.Register(
            "IsProConnected", typeof(bool), typeof(ControllersStatusView), new PropertyMetadata(default(bool)));

        public bool IsProConnected
        {
            get => (bool) GetValue(IsProConnectedProperty);
            set => SetValue(IsProConnectedProperty, value);
        }

        public static readonly DependencyProperty LeftJoyConStatusProperty = DependencyProperty.Register(
            "LeftJoyConStatus", typeof(JoyConStatus), typeof(ControllersStatusView), new PropertyMetadata(default(JoyConStatus)));

        public JoyConStatus LeftJoyConStatus
        {
            get => (JoyConStatus) GetValue(LeftJoyConStatusProperty);
            set => SetValue(LeftJoyConStatusProperty, value);
        }

        public static readonly DependencyProperty RightJoyConStatusProperty = DependencyProperty.Register(
            "RightJoyConStatus", typeof(JoyConStatus), typeof(ControllersStatusView), new PropertyMetadata(default(JoyConStatus)));

        public JoyConStatus RightJoyConStatus
        {
            get => (JoyConStatus) GetValue(RightJoyConStatusProperty);
            set => SetValue(RightJoyConStatusProperty, value);
        }

        public static readonly DependencyProperty LeftJoyConColorProperty = DependencyProperty.Register(
            "LeftJoyConColor", typeof(Color), typeof(ControllersStatusView), new PropertyMetadata(DefaultJoyConBodyColor));

        public Color LeftJoyConColor
        {
            get => (Color) GetValue(LeftJoyConColorProperty);
            set => SetValue(LeftJoyConColorProperty, value);
        }

        public static readonly DependencyProperty RightJoyConColorProperty = DependencyProperty.Register(
            "RightJoyConColor", typeof(Color), typeof(ControllersStatusView), new PropertyMetadata(DefaultJoyConBodyColor));

        public Color RightJoyConColor
        {
            get => (Color) GetValue(RightJoyConColorProperty);
            set => SetValue(RightJoyConColorProperty, value);
        }

        public ControllersStatusView()
        {
            InitializeComponent();
        }
    }
}
