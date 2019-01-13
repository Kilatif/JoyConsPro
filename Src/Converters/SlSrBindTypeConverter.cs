using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    public class SlSrBindTypeConverter : BaseConverter<SlSrBindType, int>
    {
        protected override int Convert(SlSrBindType value)
        {
            return (int) value;
        }

        protected override SlSrBindType ConvertBack(int propertyValue)
        {
            return (SlSrBindType) propertyValue;
        }
    }
}
