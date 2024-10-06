using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPIApp.Converters
{
    public class TimeFormatterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeString)
            {
                // Assuming the time string is in the format "2024-09-12 15:00"
                if (DateTime.TryParse(timeString, out DateTime dateTime))
                {
                    return dateTime.ToString("HH:mm"); // Format as "15:00"
                }
            }
            return value;
        } 

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
