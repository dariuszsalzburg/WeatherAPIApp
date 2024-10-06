using System;
using System.Globalization;


namespace WeatherAPIApp.Converters
{
    public class KmHToMsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double kmhValue)
            {
                // Przeliczanie km/h na m/s
                double msValue = kmhValue * 0.27778;
                return msValue.ToString("F1"); // Zwracamy wartość z dokładnością do 2 miejsc po przecinku
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
