using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;

namespace SuperMarket.Converters
{
    public class StockProdusConverter : IValueConverter
    {
        private ProductBLL _productBLL = new ProductBLL();
        private CategoryBLL _categoryBLL = new CategoryBLL();
        private ProducerBLL _producerBLL = new ProducerBLL();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Stock))
                return null;

            Stock stock = (Stock)value;
            string option = (string)parameter;

            Product product = _productBLL.GetProduct(stock.ProductId);
            if (option == "NumeProdus") return product.Name;
            if (option == "CodDeBare") return  product.Barcode;
            if (option == "Categorie") return _categoryBLL.GetCategoryName(product);
            if (option == "Producator") return _producerBLL.GetProducerName(product);
            return stock;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
