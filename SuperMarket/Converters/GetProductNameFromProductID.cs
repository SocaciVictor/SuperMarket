using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SuperMarket.Converters
{
    public class GetProductNameFromProductID : IValueConverter
    {
        private ProductBLL productBLL = new ProductBLL();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null || !(value is int))
                return null;

            int product = (int)value;

            return productBLL.GetProductName(product);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
