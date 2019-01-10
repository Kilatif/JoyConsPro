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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JoyConsPro.Src.Views
{
    public enum JoyConStatus
    {
        Connected,
        Disconnected,
        Unlinked
    }

    /// <summary>
    /// Interaction logic for ControllersStatusView.xaml
    /// </summary>
    public partial class ControllersStatusView : UserControl
    {
        public const double UnlinkedOpacity = 0.25;
        public static readonly Color JoyConDisconnected = Colors.Red;
        public static readonly Color ProDisconnectedColor = Color.FromRgb(255, 100, 100);
        public static readonly Color ConnectedColor = Color.FromRgb(50, 150, 0);

        private bool _isProConnected;
        private JoyConStatus _leftJoyConStatus;
        private JoyConStatus _rightJoyConStatus;

        public bool IsProConnected
        {
            get => _isProConnected;
            set
            {
                _isProConnected = value;
                IsProConnectedChanged(value);
            }
        }
        public JoyConStatus LeftJoyConStatus
        {
            get => _leftJoyConStatus;
            set
            {
                _leftJoyConStatus = value; 
                LeftJoyConStatusChanged(value);
            }
        }
        public JoyConStatus RightJoyConStatus
        {
            get => _rightJoyConStatus;
            set
            {
                _rightJoyConStatus = value;
                RightJoyConStatusChanged(value);
            }
        }

        public ControllersStatusView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            IsProConnected = false;
            LeftJoyConStatus = JoyConStatus.Unlinked;
            RightJoyConStatus = JoyConStatus.Unlinked;
        }

        private void IsProConnectedChanged(bool value)
        {
            ProBody.Stroke = new SolidColorBrush(value ? ConnectedColor : ProDisconnectedColor);
        }

        private void LeftJoyConStatusChanged(JoyConStatus value)
        {
            var effect = ((DropShadowEffect)JoyConLeftBody.Effect);
            effect.Opacity = value == JoyConStatus.Unlinked ? 0.0 : 1.0;
            JoyConLeft.Opacity = value == JoyConStatus.Unlinked ? UnlinkedOpacity : 1.0;
            switch (value)
            {
                case JoyConStatus.Connected:
                    effect.Color = ConnectedColor;
                    break;
                case JoyConStatus.Disconnected:
                    effect.Color = JoyConDisconnected;
                    break;
            }
        }

        private void RightJoyConStatusChanged(JoyConStatus value)
        {
            var effect = ((DropShadowEffect)JoyConRightBody.Effect);
            effect.Opacity = value == JoyConStatus.Unlinked ? 0.0 : 1.0;
            JoyConRight.Opacity = value == JoyConStatus.Unlinked ? UnlinkedOpacity : 1.0;
            switch (value)
            {
                case JoyConStatus.Connected:
                    effect.Color = ConnectedColor;
                    break;
                case JoyConStatus.Disconnected:
                    effect.Color = JoyConDisconnected;
                    break;
            }
        }
    }
}
