using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace JoyConsPro.Converters
{
    public abstract class BaseMultiValueConverter<TProperty, TValue1, TValue2>
        : BaseMultiValueConverter<TProperty, TValue1, TValue2, object>
    {
        public override TProperty Convert(TValue1 val1, TValue2 val2, object val3)
        {
            return Convert(val1, val2);
        }

        public override void BackConvert(TProperty property, out TValue1 val1, out TValue2 val2, out object val3)
        {
            BackConvert(property, out val1, out val2);
            val3 = null;
        }

        public abstract TProperty Convert(TValue1 val1, TValue2 val2);
        public abstract void BackConvert(TProperty property, out TValue1 val1, out TValue2 val2);
    }

    public abstract class BaseMultiValueConverter<TProperty, TValue1, TValue2, TValue3> 
        : BaseMultiValueConverter<TProperty, TValue1, TValue2, TValue3, object>
    {
        public override TProperty Convert(TValue1 val1, TValue2 val2, TValue3 val3, object val4)
        {
            return Convert(val1, val2, val3);
        }

        public override void BackConvert(TProperty property, out TValue1 val1, out TValue2 val2, out TValue3 val3, out object val4)
        {
            BackConvert(property, out val1, out val2, out val3);
            val4 = null;
        }

        public abstract TProperty Convert(TValue1 val1, TValue2 val2, TValue3 val3);
        public abstract void BackConvert(TProperty property, out TValue1 val1, out TValue2 val2, out TValue3 val3);
    }

    public abstract class BaseMultiValueConverter<TProperty, TValue1, TValue2, TValue3, TValue4> : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var valuesCheck = values?.All(value => (value is TValue1 || value is TValue2 || 
                                                   value is TValue3 || value is TValue4) && value != DependencyProperty.UnsetValue) ?? false;

            if (!valuesCheck || targetType != typeof(TProperty))
            {
                return DependencyProperty.UnsetValue;
            }

            var val1 = values.Length >= 1 ? (TValue1)values[0] : default(TValue1);
            var val2 = values.Length >= 2 ? (TValue2)values[1] : default(TValue2);
            var val3 = values.Length >= 3 ? (TValue3)values[2] : default(TValue3);
            var val4 = values.Length >= 4 ? (TValue4)values[3] : default(TValue4);

            return Convert(val1, val2, val3, val4);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var targetesCheck = targetTypes?.All(target => target == typeof(TValue1) || target == typeof(TValue2) ||
                                                           target == typeof(TValue3) || target == typeof(TValue4)) ?? false;

            if (value is TProperty property && targetesCheck)
            {
                BackConvert(property, out var val1, out var val2, out var val3, out var val4);
                return new object[] {val1, val2, val3, val4};
            }

            return targetTypes?.Select(target => DependencyProperty.UnsetValue).ToArray();
        }

        public abstract TProperty Convert(TValue1 val1, TValue2 val2, TValue3 val3, TValue4 val4);
        public abstract void BackConvert(TProperty property, out TValue1 val1, out TValue2 val2, out TValue3 val3, out TValue4 val4);
    }
}
