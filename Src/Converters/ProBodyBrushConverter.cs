using System.Windows.Media;

namespace JoyConsPro.Converters
{
    class ProBodyBrushConverter : BaseConverter<bool, Brush>
    {
        public static readonly Color DisconnectedColor = Color.FromRgb(255, 100, 100);
        public static readonly Color ConnectedColor = Color.FromRgb(50, 150, 0);

        protected override Brush Convert(bool value)
        {
            return value ? new SolidColorBrush(ConnectedColor) : new SolidColorBrush(DisconnectedColor);
        }

        protected override bool ConvertBack(Brush propertyValue)
        {
            return default(bool);
        }
    }
}
