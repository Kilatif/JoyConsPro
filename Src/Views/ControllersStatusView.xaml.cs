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

        public ControllersStatusView()
        {
            InitializeComponent();
        }
    }
}
