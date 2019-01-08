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
        private const double UnlinkedOpacity = 0.25;
        private static readonly Color JoyConDisconnected = Colors.Red;
        private static readonly Color ProDisconnectedColor = Color.FromRgb(255, 100, 100);
        private static readonly Color ConnectedColor = Color.FromRgb(50, 150, 0);

        public bool IsProConnected { set => ProBody.Stroke = new SolidColorBrush(value ? ConnectedColor : ProDisconnectedColor); }
        public JoyConStatus LeftJoyConStatus
        {
            set
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
        }

        public JoyConStatus RightJoyConStatus
        {
            set
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

        public ControllersStatusView()
        {
            InitializeComponent();
        }

        /*public Color Test
        {
            get => (Color)GetValue(TestProperty);
            set => SetValue(TestProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(Color), typeof(ControllersStatusView), new PropertyMetadata(Color.FromRgb(0, 0, 0)));*/
    }
}
