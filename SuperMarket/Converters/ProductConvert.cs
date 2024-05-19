using SuperMarket.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SuperMarket.Converters
{
    public class ProductConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                int categoryId;
                int producerId;

                if (int.TryParse(values[2]?.ToString(), out categoryId) && int.TryParse(values[3]?.ToString(), out producerId))
                {
                    return new Product()
                    {
                        Name = values[0].ToString(),
                        Barcode = values[1].ToString(),
                        CategoryId = categoryId,
                        ProducerId = producerId,
                        IsActive = true
                    };
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
