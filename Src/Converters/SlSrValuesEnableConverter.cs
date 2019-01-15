using JoyConsPro.ViewModels;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class SlSrValuesEnableConverter : BaseConverter<SlSrBindType, bool>
    {
        protected override bool Convert(SlSrBindType value)
        {
            return value == SlSrBindType.SensLevelValueGyroOnOff;
        }

        protected override SlSrBindType ConvertBack(bool propertyValue)
        {
            return default(SlSrBindType);
        }
    }
}
