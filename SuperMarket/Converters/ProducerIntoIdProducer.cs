using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SuperMarket.Converters
{
    public class ProducerIntoIdProducer : IValueConverter
    {
        public static List<Producer> Producers { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Producer producer)
            {
                return producer.Id;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {
                var producer = Producers?.FirstOrDefault(p => p.Id == id);
                return producer?.Name ?? string.Empty;
            }
            return value;
        }
    }
}
