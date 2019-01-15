using System.Windows.Media;
using JoyConsPro.ViewModels;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class JoyConBodyFillConverter : BaseMultiValueConverter<Brush, Color, JoyConStatus>
    {
        private static readonly Color DefaultColor = Color.FromRgb(122, 122, 122);

        public override Brush Convert(Color color, JoyConStatus status)
        {
            return status == JoyConStatus.Unlinked
                ? new SolidColorBrush(DefaultColor)
                : new SolidColorBrush(color);
        }

        public override void BackConvert(Brush property, out Color color, out JoyConStatus status)
        {
            color = default(Color);
            status = default(JoyConStatus);
        }
    }
}
