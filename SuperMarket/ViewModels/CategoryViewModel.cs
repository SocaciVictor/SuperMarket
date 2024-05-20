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
    public class CategoryViewModel: BasePropertyChanged
    {
        private CategoryBLL _categoryBLL;

        public CategoryViewModel()
        {
            _categoryBLL = new CategoryBLL();
            CategoriesList = _categoryBLL.GetAllCategories();
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


        #region Data Members

        public ObservableCollection<Category> CategoriesList 
        {
            get => _categoryBLL.CategoriesList; 
            set => _categoryBLL.CategoriesList = value;
        }

        #endregion


        #region Command Region


        public void AddMethod(object obj)
        {
            _categoryBLL.AddMethod(obj);
            ErrorMessage = _categoryBLL.ErrorMessage;
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
            _categoryBLL.UpdateMethod(obj);
            ErrorMessage = _categoryBLL.ErrorMessage;
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
            _categoryBLL.DeleteMethod(obj);
            ErrorMessage = _categoryBLL.ErrorMessage;
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
