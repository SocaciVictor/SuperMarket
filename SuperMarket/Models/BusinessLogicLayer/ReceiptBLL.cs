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

        public ObservableCollection<ReceiptDetail> ReceiptDetailsList { get; set; }

        public string ErrorMessage { get; set; }

        public ReceiptBLL()
        {
            ReceiptsList = new ObservableCollection<Receipt>();
            ReceiptDetailsList = new ObservableCollection<ReceiptDetail>();
        }


        public ObservableCollection<Receipt> GetAllReceipts()
        {
            List<Receipt> receipts = context.Receipts.ToList();
            ObservableCollection<Receipt>result = new ObservableCollection<Receipt>();
            foreach (Receipt receipt in receipts)
            {
                result.Add(receipt);
            }    
            return result;
        }

        public void AddMethod(object obj)
        {
            Receipt receipt = obj as Receipt;

            if (receipt != null)
            {
                context.Receipts.Add(receipt);
                context.SaveChanges();
                receipt.ReceiptId = context.Receipts.Max(item => item.ReceiptId);
                ReceiptsList.Add(receipt);
            }
        }
    }
}
