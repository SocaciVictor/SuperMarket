using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;
using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows;

namespace SuperMarket.ViewModels
{
    
    public class CashierViewModel: BasePropertyChanged
    {
        private ReceiptBLL _receiptBLL;
        private ProducerBLL _producerBLL;
        private ProductBLL _productBLL;
        private StockBLL _stockBLL;
        private CategoryBLL _categoryBLL;
        private ReceiptDetailBLL _receiptDetailBLL;
        private User currentUser;
        public ObservableCollection<Stock> StocksListFiltred { get; set; }

        public CashierViewModel(object param)
        {
            currentUser = param as User;
            _receiptBLL = new ReceiptBLL();
            _producerBLL = new ProducerBLL();   
            _productBLL = new ProductBLL();
            _stockBLL = new StockBLL();
            _categoryBLL = new CategoryBLL();
            _receiptDetailBLL = new ReceiptDetailBLL();
            StocksListFiltred = new ObservableCollection<Stock>(_stockBLL.GetAllStocks());
            ReceiptsList = new ObservableCollection<Receipt>(_receiptBLL.GetAllReceipts());
            ReceiptDetailsList = new ObservableCollection<ReceiptDetail>();
            CreatedReceipt = new Receipt();
        }


        #region Data Members

        public ObservableCollection<Category> CategoriesList
        {
            get => _categoryBLL.CategoriesList;
            set => _categoryBLL.CategoriesList = value;
        }

        public ObservableCollection<ReceiptDetail> ReceiptDetailsFromBD
        {
            get => _receiptDetailBLL.ReceiptDetailsList;
            set => _receiptDetailBLL.ReceiptDetailsList = value;
        }
        public ObservableCollection<ReceiptDetail> ReceiptDetailsList { get; set; }

        public ObservableCollection<Receipt> ReceiptsList
        {
            get => _receiptBLL.ReceiptsList;
            set => _receiptBLL.ReceiptsList = value;
        }

        public ObservableCollection<Producer> ProducersList
        {
            get => _producerBLL.ProducersList;
            set => _producerBLL.ProducersList = value;
        }

        public ObservableCollection<Product> ProductsList
        {
            get => _productBLL.ProductsList;
            set => _productBLL.ProductsList = value;
        }

        public ObservableCollection<Stock> StocksList
        {
            get => _stockBLL.StocksList;
            set => _stockBLL.StocksList = value;
        }


        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                NotifyPropertyChanged(nameof(ProductName));
                UpdateStockList();
            }
        }



        private string _barCode;
        public string BarCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                _barCode = value;
                NotifyPropertyChanged(nameof(BarCode));
                UpdateStockList();
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged(nameof(SelectedCategory));
                UpdateStockList();
            }
        }

        private Producer _selectedProducer;
        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                NotifyPropertyChanged(nameof(SelectedProducer));
                UpdateStockList();
            }
        }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get 
            {
                if (!DateEnable)
                    return null;

                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged(nameof(SelectedDate));
                UpdateStockList();
            }
        }

        private bool _dateEnable;
        public bool DateEnable
        {
            get => _dateEnable;
            set
            {
                _dateEnable = value;
                NotifyPropertyChanged(nameof(DateEnable));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set 
            {
                if (value != 0 && value != _quantity)
                {
                    _quantity = value;
                    NotifyPropertyChanged(nameof(Quantity));
                }
            }
        }

        private double _sumaTotala;
        public double SumaTotala
        {
            get => _sumaTotala;
            set
            {
                _sumaTotala = value;
                NotifyPropertyChanged(nameof(SumaTotala));
            }
        }

        private Receipt _receipt;
        public Receipt CreatedReceipt
        {
            get => _receipt;
            set 
            {
                _receipt = value;
                NotifyPropertyChanged(nameof(Receipt));
            }
        }



        #endregion

        #region 

        private void UpdateStockList()
        {
            StocksListFiltred.Clear();
            foreach (Stock stock in _stockBLL.SearchStocForCashier(ProductName, BarCode, SelectedCategory?.Id, SelectedProducer?.Id, SelectedDate))
            {
                StocksListFiltred.Add(stock);
            }
        }


        private ICommand pressPlusCommand;
        public ICommand PressPlusCommand
        {
            get 
            {
                if (pressPlusCommand == null)
                {
                    pressPlusCommand = new RelayCommand(AddReceiptTemporary);
                }
                return pressPlusCommand;
            }


        }

        private void AddReceiptTemporary(object obj)
        {
            Stock stock = (Stock)obj;
            Product product = _productBLL.GetProduct(stock.ProductId);
            ReceiptDetail receiptDetail = (ReceiptDetail)ReceiptDetailsList.FirstOrDefault(receipt => receipt.IdProduct == product.Id);
            if (receiptDetail != null && receiptDetail.Amount < stock.Amount)
            {

                receiptDetail.Amount += 1;
                SumaTotala -= receiptDetail.Subtotal;
                receiptDetail.Subtotal = receiptDetail.Amount * stock.SellingAmount;
                CollectionViewSource.GetDefaultView(ReceiptDetailsList).Refresh();
                SumaTotala += receiptDetail.Subtotal;
            }
            else if (receiptDetail == null)
            {
                ReceiptDetail receiptDetailNew = new ReceiptDetail();
                receiptDetailNew.IdProduct = product.Id;
                receiptDetailNew.Amount = 1;
                receiptDetailNew.Subtotal = receiptDetailNew.Amount * stock.SellingAmount;
                ReceiptDetailsList.Add(receiptDetailNew);
                SumaTotala += receiptDetailNew.Subtotal;
            }
            if (CreatedReceipt == null)
            {
                CreatedReceipt.ReceiptAmount = (float)SumaTotala;
            }
        }


        private void UpdateReceiptDetail(object param)
        {
            Receipt receipt = param as Receipt;
            receipt.ReceiptDate = DateTime.Now;
            receipt.UserId = currentUser.Id;
            receipt.ReceiptAmount = (float)SumaTotala;
            ReceiptsList.Add(receipt);
            _receiptBLL.AddMethod(receipt);
            int id  = _receiptBLL.ReceiptsList.Last().ReceiptId;
            foreach (ReceiptDetail receiptDetail in ReceiptDetailsList)
            {
                receiptDetail.ReceiptId = id;
                _receiptDetailBLL.AddMethod(receiptDetail);
                ReceiptDetailsFromBD.Add(receiptDetail);
                _stockBLL.DeleteProductFromStock(receiptDetail);
            }
            StocksListFiltred.Clear();
            foreach (Stock stock in StocksList)
            {
                StocksListFiltred.Add(stock);
            }
            ReceiptDetailsList.Clear();
            SumaTotala = 0;
        }

        private ICommand _backToCreateCommand;
        public ICommand BackToCreateCommand
        {
            get
            {
                if (_backToCreateCommand == null)
                    _backToCreateCommand = new RelayCommand(UpdateReceiptDetail);
                return _backToCreateCommand;
            }
        }

        #endregion
    }
}
