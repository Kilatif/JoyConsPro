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
        private static readonly Color JoyConGrey = Color.FromRgb(122, 122, 122);
        private static readonly Color JoyConDisconnected = Colors.Red;
        private static readonly Color ProDisconnectedColor = Color.FromRgb(255, 100, 100);
        private static readonly Color ConnectedColor = Color.FromRgb(50, 150, 0);

        public bool IsProConnected { set => ProBody.Stroke = new SolidColorBrush(value ? ConnectedColor : ProDisconnectedColor); }
        public JoyConStatus LeftJoyConStatus
        {
            set
            {
                JoyConLeft.Opacity = value == JoyConStatus.Unlinked ? UnlinkedOpacity : 1.0;
                switch (value)
                {
                    case JoyConStatus.Unlinked:
                        JoyConLeftBody.Stroke = new SolidColorBrush(JoyConGrey);
                        break;
                    case JoyConStatus.Connected:
                        JoyConLeftBody.Stroke = new LinearGradientBrush(ConnectedColor, JoyConGrey, 0);
                        break;
                    case JoyConStatus.Disconnected:
                        JoyConLeftBody.Stroke = new LinearGradientBrush(JoyConDisconnected, JoyConGrey, 0);
                        break;
                }
            }
        }

        public JoyConStatus RightJoyConStatus
        {
            set
            {
                JoyConRight.Opacity = value == JoyConStatus.Unlinked ? UnlinkedOpacity : 1.0;
                switch (value)
                {
                    case JoyConStatus.Unlinked:
                        JoyConRightBody.Stroke = new SolidColorBrush(JoyConGrey);
                        break;
                    case JoyConStatus.Connected:
                        JoyConRightBody.Stroke = new LinearGradientBrush(JoyConGrey, ConnectedColor, 0);
                        break;
                    case JoyConStatus.Disconnected:
                        JoyConRightBody.Stroke = new LinearGradientBrush(JoyConGrey, JoyConDisconnected, 0);
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
