using JoyConsPro.ViewModels;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class TypeSettingConverter : BaseConverter<JoyConType, object>
    {
        protected override object Convert(JoyConType value)
        {
            switch (value)
            {
                case JoyConType.Left:
                    return "Left : ";
                case JoyConType.Right:
                    return "Right : ";
                default:
                    return "Unknown : ";
            }
        }

        protected override JoyConType ConvertBack(object propertyValue)
        {
            return default(JoyConType);
        }
    }
}
