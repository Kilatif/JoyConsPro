using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class JoyConEffectConverter : BaseMultiPropertyConverter<JoyConStatus, Color, double>
    {
        public static readonly Color DisconnectedColor = Colors.Red;
        public static readonly Color ConnectedColor = Color.FromRgb(50, 150, 0);
        
        protected override void FillConverter(JoyConStatus value)
        {
            switch (value)
            {
                case JoyConStatus.Unlinked:
                    Set(Colors.White);
                    Set(0.0d);
                    break;

                case JoyConStatus.Connected:
                    Set(ConnectedColor);
                    Set(1.0d);
                    break;

                case JoyConStatus.Disconnected:
                    Set(DisconnectedColor);
                    Set(1.0d);
                    break;
            }
        }

        protected override JoyConStatus ConvertBack(Color propValue)
        {
            return default(JoyConStatus);
        }
    }
}
