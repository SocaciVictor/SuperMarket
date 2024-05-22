using System;
using System.Globalization;
using System.Windows.Data;
using SuperMarket.Models;

namespace SuperMarket.Converters
{
    public class StockConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return null;

            float amount;
            float purchase;
            DateTime supplyDate;
            DateTime expirationDate;
            string unit = values[1]?.ToString();
            int prodID;

            if (!float.TryParse(values[0]?.ToString(), out amount) ||
                !DateTime.TryParse(values[2]?.ToString(), out supplyDate) ||
                !DateTime.TryParse(values[3]?.ToString(), out expirationDate) ||
                !float.TryParse(values[4]?.ToString(), out purchase) ||
                !int.TryParse(values[5]?.ToString(), out prodID))
            {
                return null;
            }

            return new Stock
            {
                ProductId = prodID,
                Amount = amount,
                Unit = unit,
                SupplyDate = supplyDate,
                ExpirationDate = expirationDate,
                PurchasePrice = purchase,
                IsActive = true
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
