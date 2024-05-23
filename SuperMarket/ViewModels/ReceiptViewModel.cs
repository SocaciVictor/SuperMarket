using SuperMarket.Helpers;
using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModels
{
    public class ReceiptViewModel: BasePropertyChanged
    {
        private ReceiptBLL _receiptBLL;
        public ICommand ViewReceiptCommand { get; set; }
        public ReceiptViewModel()
        {
            _receiptBLL = new ReceiptBLL();
            ReceiptsList = _receiptBLL.GetAllReceipts();
            ViewReceiptCommand = new RelayCommand(ViewReceipt);
        }


        #region Data Members


        public ObservableCollection<Receipt> ReceiptsList
        {
            get => _receiptBLL.ReceiptsList;
            set => _receiptBLL.ReceiptsList = value;
        }

        #endregion


        #region Methods


        private void ViewReceipt(object param)
        {
            
            if (param != null)
            {
                Receipt selectedReceipt = (Receipt)param;
                ReceiptDetailWindow receiptWindow = new ReceiptDetailWindow(selectedReceipt);
                receiptWindow.Show();
            }
        }

        #endregion
    }
}
