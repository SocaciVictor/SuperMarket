using System;
using System.Globalization;
using System.Windows.Data;
using SuperMarket.Models;

namespace SuperMarket.Converters
{
    public class UserConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 3)
            {
                if (values[0] != null && values[1] != null && values[2] != null)
                {

                    int userType;
                    // Converitm valorile în întregi
                    if (int.TryParse(values[2]?.ToString(), out userType))
                    {
                        return new User()
                        {
                            Name = values[0].ToString(),
                            Password = values[1].ToString(),
                            Type = userType,
                            IsActive = true
                        };
                    }
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
