using SuperMarket.Helpers;
using SuperMarket.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models.BusinessLogicLayer
{
    public class StockBLL: BasePropertyChanged
    {
        private SupermarketDBContext context = new SupermarketDBContext();

        private StocDAL _stocDAL = new StocDAL();
        public ObservableCollection<Stock> StocksList { get; set; }

        public string ErrorMessage { get; set; }

        public StockBLL()
        {
            StocksList = new ObservableCollection<Stock>(GetAllStocks());
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Stock stock = obj as Stock;
            if (stock != null)
            {
                if (stock.Amount < 1)
                {
                    ErrorMessage = "Cantitatea trebuie sa fie pozitiva";
                }
                else if (stock.SupplyDate == DateTime.MinValue)
                {
                    ErrorMessage = "Data de aprovizionare trebuie precizată";
                }
                else if (stock.ExpirationDate == DateTime.MinValue)
                {
                    ErrorMessage = "Data de expirare trebuie precizată";
                }
                else if (IsInDataBase(stock) == true)
                {
                    ErrorMessage = "Stock-ul exista deja in baza de date!";
                } 
                else
                {
                    stock.SellingAmount = (float)(stock.PurchasePrice + 0.25 * stock.PurchasePrice);
                    context.Stocks.Add(stock);
                    context.SaveChanges();
                    stock.Id = context.Products.Max(item => item.Id);
                    StocksList.Add(stock);
                    ErrorMessage = "";
                }
            }
        }



        private bool IsInDataBase(Stock stock)
        {
            foreach (var item in StocksList)
            {
                if (item.ProductId == stock.ProductId && item.IsActive == true)
                {
                    return true;
                }
            }
            return false;
        }

        public ObservableCollection<Stock> GetAllStocks()
        {
            List<Stock> stocks = context.Stocks.ToList();
            ObservableCollection<Stock> result = new ObservableCollection<Stock>();
            foreach (Stock stock in stocks)
            {
                if (stock.IsActive == true)
                {
                    result.Add(stock);
                }
            }
            return result;

        }

        public ObservableCollection<Stock> SearchStocForCashier(string numeProdus, string codDeBare,
         int? categorieId, int? producatorId, DateTime? dataExpirare)
        {
            return _stocDAL.SearchStocForCashier(numeProdus, codDeBare, categorieId, producatorId, dataExpirare);
        }

        public void DeleteProductFromStock(ReceiptDetail receiptDetail)
        {
            if (receiptDetail != null)
            {
                Stock stockDelete = StocksList.Where(stock => stock.ProductId == receiptDetail.IdProduct).FirstOrDefault();
                if (stockDelete.Amount - receiptDetail.Amount >= 0)
                {
                    stockDelete.Amount -= receiptDetail.Amount;
                }
                if (stockDelete.Amount == 0) {
                    stockDelete.IsActive = false;
                    StocksList.Remove(stockDelete);
                }
                context.SaveChanges();
            }
        }
    }
}
