using SRB_Rail_Timetable.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SRB_Rail_Timetable.Converters
{
    /// <summary>
    /// Used to get text color based on Timespan.
    /// </summary>
    public class TimespanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var span = (TimeSpan)value;
            if (span.TotalMinutes > 0)
            {
                return Application.Current.Resources["invalidTextColor"];
            }

            return Application.Current.Resources["tableItemTextColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
