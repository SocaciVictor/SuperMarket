using SuperMarket.Helpers;
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

        public string ErrorMessage { get; set; }

        public ReceiptDetailBLL()
        {
            ReceiptDetailsList = new ObservableCollection<ReceiptDetail>(GetAllReceiptDetail());
        }

        public ObservableCollection<ReceiptDetail> GetAllReceiptDetail()
        {
            List<ReceiptDetail> receiptDetails = context.ReceiptDetails.ToList();
            ObservableCollection<ReceiptDetail> result = new ObservableCollection<ReceiptDetail>();
            foreach (var receiptDetail in receiptDetails)
            {
                result.Add(receiptDetail);
            }
            return result;
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            ReceiptDetail receiptDetail = obj as ReceiptDetail;

            if (receiptDetail != null)
            {
                context.ReceiptDetails.Add(receiptDetail);
                context.SaveChanges();
                receiptDetail.Id = context.ReceiptDetails.Max(item => item.Id);
                ReceiptDetailsList.Add(receiptDetail);
            }
            
        }

        public ObservableCollection<ReceiptDetail> GetReceiptDetailWithCurrentReceiptId(Receipt currentReceipt)
        {
            ObservableCollection<ReceiptDetail> result = new ObservableCollection<ReceiptDetail>();
            var receiptDetails = ReceiptDetailsList.Where(r => r.ReceiptId == currentReceipt.ReceiptId).ToList();
            foreach (var receiptDetail in receiptDetails)
            {
                result.Add(receiptDetail);
            }
            return result;
        }
    }
}
