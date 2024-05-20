using SuperMarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Models;

namespace SuperMarket.Converters
{
    public class CategoryIdToNameConverter : IValueConverter
    {
        private CategoryBLL categoryBLL = new CategoryBLL();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Product))
                return null;

            Product product = (Product)value;

            return categoryBLL.GetCategoryName(product);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
