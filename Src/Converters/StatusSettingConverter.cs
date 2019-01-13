using System.Windows.Media;
using JoyConsPro.Views;

namespace JoyConsPro.Converters
{
    public class StatusSettingConverter : BaseMultiPropertyConverter<JoyConStatus, Brush, bool, object>
    {
        protected override void FillConverter(JoyConStatus value)
        {
            switch (value)
            {
                case JoyConStatus.Unlinked:
                    Set<Brush>(new SolidColorBrush(Color.FromArgb(180, 0, 0, 0)));
                    Set<bool>(false);
                    Set<object>("Unlinked");
                    break;
                case JoyConStatus.Disconnected:
                    Set<Brush>(new SolidColorBrush(Color.FromArgb(180, 255, 0, 0)));
                    Set<bool>(false);
                    Set<object>("Disconnected");
                    break;
                case JoyConStatus.Connected:
                    Set<Brush>(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)));
                    Set<bool>(true);
                    Set<object>("");
                    break;
            }
        }
    }
}
