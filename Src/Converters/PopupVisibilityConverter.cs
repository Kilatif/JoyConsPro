using System.Windows;

namespace JoyConsPro.Converters
{
    class PopupVisibilityConverter : BaseConverter<bool, Visibility>
    {
        protected override Visibility Convert(bool value)
        {
            return value ? Visibility.Visible : Visibility.Hidden;
        }

        protected override bool ConvertBack(Visibility propertyValue)
        {
            return propertyValue == Visibility.Visible;
        }
    }
}
