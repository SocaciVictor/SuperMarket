using SuperMarket.Helpers;
using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.ViewModels
{
    public class ReceiptDetailViewModel : BasePropertyChanged
    {
        private ReceiptDetailBLL _receiptDetailBLL;
        public Receipt currentReceipt { get; set; }
        public ReceiptDetailViewModel(object param)
        {
            currentReceipt = param as Receipt;
            _receiptDetailBLL = new ReceiptDetailBLL();
            ReceiptDetailsList = _receiptDetailBLL.GetReceiptDetailWithCurrentReceiptId(currentReceipt);
        }

        #region Data Members

        public ObservableCollection<ReceiptDetail> ReceiptDetailsList 
        {
            get => _receiptDetailBLL.ReceiptDetailsList;
            set => _receiptDetailBLL.ReceiptDetailsList = value;
        }

        #endregion

        #region Methods
        #endregion
    }
}
