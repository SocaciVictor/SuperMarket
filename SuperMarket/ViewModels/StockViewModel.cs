using SuperMarket.Helpers;
using SuperMarket.Models;
using SuperMarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModels
{
    public class StockViewModel : BasePropertyChanged
    {
        private StockBLL _stockBLL;

        private ProductBLL _productBLL;

        public StockViewModel()
        {
            _stockBLL = new StockBLL();
            _productBLL = new ProductBLL();
            StockList = _stockBLL.GetAllStocks();
            ProductList = _productBLL.GetAllProducts();
        }

        #region Data Members

        private ObservableCollection<Stock> _stockList;
        public ObservableCollection<Stock> StockList
        {
            get => _stockBLL.StocksList;
            set
            { 
                _stockBLL.StocksList = value; 
                NotifyPropertyChanged(nameof(StockList));
            }
        }

        public ObservableCollection<Product> ProductList
        {
            get => _productBLL.ProductsList;
            set => _productBLL.ProductsList = value;
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }


        #endregion

        #region Command Region


        public void AddMethod(object obj)
        {
            _stockBLL.AddMethod(obj);
            StockList = _stockBLL.GetAllStocks();
            ErrorMessage = _stockBLL.ErrorMessage;
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddMethod);
                }
                return addCommand;
            }
        }
        #endregion
    }
}
