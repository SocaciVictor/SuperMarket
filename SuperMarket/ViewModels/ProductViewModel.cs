using SuperMarket.Converters;
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
    public class ProductViewModel: BasePropertyChanged
    {
        private ProductBLL _productsBLL;
        private CategoryBLL _categoryBLL;
        private ProducerBLL _producerBLL;
        public ProductViewModel()
        {
            _productsBLL = new ProductBLL();
            _categoryBLL = new CategoryBLL();
            _producerBLL = new ProducerBLL();
            ProductsList = _productsBLL.GetAllProducts();
            ProducersList = _producerBLL.GetAllProducers();
            CategoriesList = _categoryBLL.GetAllCategories();
        }

        #region Data Members

        public ObservableCollection<Product>? ProductsList
        {
            get => _productsBLL.ProductsList;
            set => _productsBLL.ProductsList = value;
        }

        public ObservableCollection<Producer>? ProducersList
        {
            get => _producerBLL.ProducersList;
            set => _producerBLL.ProducersList = value;
        }

        public ObservableCollection<Category>? CategoriesList
        {
            get => _categoryBLL.CategoriesList;
            set => _categoryBLL.CategoriesList = value;
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


        public void SelectCategoryNameBLL(object obj)
        { 
            //_categoryBLL.SelectNameFromDB(obj);
            //ErrorMessage = _categoryBLL.ErrorMessage;
        }



        private ICommand selectCategoryName;

        public ICommand SelectCategoryName
        {
            get
            {
                if (selectCategoryName == null) 
                {
                    selectCategoryName = new RelayCommand(SelectCategoryNameBLL);
                }
                return selectCategoryName;
            }
        }

        //public void CategoryNameFromDB(object obj)
        //{
        //    _categoryBLL.
        //    ErrorMessage = _categoryBLL.ErrorMessage;
        //}

        //private ICommand getCategoryName;

        //public ICommand GetCategoryName
        //{
        //    get
        //    {
        //        if(getCategoryName == null) 
        //        {
        //            getCategoryName = new RelayCommand();
        //        }
        //        return getCategoryName;
        //    }
        //}

        #endregion

        #region Command Members

        public void AddMethod(object obj)
        {
            _productsBLL.AddMethod(obj);
            ErrorMessage = _productsBLL.ErrorMessage;
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

        public void UpdateMethod(object obj)
        {
            _productsBLL.UpdateMethod(obj);
            ErrorMessage = _productsBLL.ErrorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(UpdateMethod);
                }
                return updateCommand;
            }
        }

        public void DeleteMethod(object obj)
        {
            _productsBLL.DeleteMethod(obj);
            ErrorMessage = _productsBLL.ErrorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteMethod);
                }
                return deleteCommand;
            }
        }

        #endregion
    }
}
