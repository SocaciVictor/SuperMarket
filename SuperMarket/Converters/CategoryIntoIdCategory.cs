using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SuperMarket.Converters
{
    public class CategoryIntoIdCategory : IValueConverter
    {
        public static List<Category> Categories { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Category category)
            {
                return category.Id;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {
                var category = Categories?.FirstOrDefault(c => c.Id == id);
                return category?.CategoryName ?? string.Empty;
            }
            return value;
        }
    }
}
