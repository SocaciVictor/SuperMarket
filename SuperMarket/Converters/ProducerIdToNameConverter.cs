﻿using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SuperMarket.Converters
{
    public class ProducerIdToNameConverter : IValueConverter
    {
        private ProducerBLL producerBLL = new ProducerBLL();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Product))
                return null;

            Product product = (Product)value;

            return producerBLL.GetProducerName(product);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
