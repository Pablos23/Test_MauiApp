using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_MauiApp.Converters
{
    public class PosterUrlConverter : IValueConverter
    {
        private const string BaseUrl = "https://image.tmdb.org/t/p/w500";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string posterPath && !string.IsNullOrEmpty(posterPath))
            {
                return $"{BaseUrl}{posterPath}";
            }
            return null; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
