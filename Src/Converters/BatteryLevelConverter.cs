using System.Windows.Media;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    class BatteryLevelConverter : BaseMultiPropertyConverter<BatteryLevel, string, Brush>
    {
        protected override void FillConverter(BatteryLevel value)
        {
            switch (value)
            {
                case BatteryLevel.Empty:
                    Set("....");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(200, 0, 0)));
                    break;
                case BatteryLevel.Critical:
                    Set("----");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
                    break;
                case BatteryLevel.Low:
                    Set("---#");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(255, 128, 0)));
                    break;
                case BatteryLevel.Medium:
                    Set("--##");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(255, 255, 0)));
                    break;
                case BatteryLevel.Full:
                    Set("####");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(0, 255, 0)));
                    break;
                default:
                    Set("????");
                    Set<Brush>(new SolidColorBrush(Color.FromRgb(0, 0, 0)));
                    break;
            }
        }
    }
}
