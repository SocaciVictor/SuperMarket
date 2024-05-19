using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ReceiptBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<Receipt> ReceiptsList { get; set; }

        public ReceiptBLL()
        {
            ReceiptsList = new ObservableCollection<Receipt>();
        }
    }
}
