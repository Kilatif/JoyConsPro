using System.Windows.Media;

namespace JoyConsPro.Converters
{
    class JoyConBodyFillConverter : BaseConverter<Color, Brush>
    {
        protected override Brush Convert(Color value)
        {
            return new SolidColorBrush(value);
        }

        protected override Color ConvertBack(Brush propertyValue)
        {
            return default(Color);
        }
    }
}
