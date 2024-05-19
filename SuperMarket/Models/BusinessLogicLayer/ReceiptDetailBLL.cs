﻿using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class ReceiptDetailBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();
        public ObservableCollection<ReceiptDetail> ReceiptDetailsList { get; set; }

        public ReceiptDetailBLL()
        {
            ReceiptDetailsList = new ObservableCollection<ReceiptDetail>();
        }
    }
}
