using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JoyConsPro.Converters
{
    public abstract class BaseMultiPropertyConverter<TValue, TProperty1> : BaseMultiPropertyConverter<TValue, TProperty1, object, object, object> { }
    public abstract class BaseMultiPropertyConverter<TValue, TProperty1, TProperty2> : BaseMultiPropertyConverter<TValue, TProperty1, TProperty2, object, object> { }
    public abstract class BaseMultiPropertyConverter<TValue, TProperty1, TProperty2, TProperty3> : BaseMultiPropertyConverter<TValue, TProperty1, TProperty2, TProperty3, object> { }
    public abstract class BaseMultiPropertyConverter<TValue, TProperty1, TProperty2, TProperty3, TProperty4> : IValueConverter
    {
        private readonly Dictionary<string, object> _propsValues = new Dictionary<string, object>();

        protected void Set<TProp>(TProp val)
        {
            _propsValues[typeof(TProp).Name] = val;
        }        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TValue val &&
                (targetType == typeof(TProperty1) ||
                 targetType == typeof(TProperty2) ||
                 targetType == typeof(TProperty3) ||
                 targetType == typeof(TProperty4)))
            {
                FillConverter(val);
                if (_propsValues.TryGetValue(targetType.Name, out var propVal))
                {
                    return propVal;
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        protected abstract void FillConverter(TValue value);
    }

    public abstract class BaseConverter<TValue, TProperty> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(TProperty) && value is TValue val)
            {
                return Convert(val);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(TValue) && value is TProperty val)
            {
                return ConvertBack(val);
            }

            return DependencyProperty.UnsetValue;
        }

        protected abstract TProperty Convert(TValue value);
        protected abstract TValue ConvertBack(TProperty propertyValue);
    }
}
