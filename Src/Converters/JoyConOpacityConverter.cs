using System;
using System.Globalization;
using System.Windows.Data;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class JoyConOpacityConverter : BaseConverter<JoyConStatus, double>
    {
        public const double UnlinkedOpacity = 0.25;

        protected override double Convert(JoyConStatus value)
        {
            switch (value)
            {
                case JoyConStatus.Unlinked:
                    return UnlinkedOpacity;
                default:
                    return 1.0d;
            }
        }

        protected override JoyConStatus ConvertBack(double propertyValue)
        {
            return default(JoyConStatus);
        }
    }
}
