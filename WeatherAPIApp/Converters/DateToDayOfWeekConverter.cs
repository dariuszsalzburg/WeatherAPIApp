using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPIApp.Converters
{
    public class DateToDayOfWeekConverter : IValueConverter
    {
        public string? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null; // lub zwróć domyślną wartość, jeśli to potrzebne
            }

            if (DateTime.TryParse(value.ToString(), out DateTime dateTime))
            {
                return dateTime.DayOfWeek.ToString();
            }

            return null; // lub inna odpowiednia wartość w przypadku błędu parsowania
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
