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
    public class UserViewModel: BasePropertyChanged
    {
        private UserBLL _userBLL;
        public UserViewModel()
        {
            _userBLL = new UserBLL();
            UsersList = _userBLL.GetAllUsers();
        }

        #region Data Members

        private ObservableCollection<User> _usersList;
        public ObservableCollection<User> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                NotifyPropertyChanged(nameof(UsersList));
            }
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
            _userBLL.AddMethod(obj);
            ErrorMessage = _userBLL.ErrorMessage;
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
            _userBLL.UpdateMethod(obj);
            ErrorMessage = _userBLL.ErrorMessage;
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
            _userBLL.DeleteMethod(obj);
            ErrorMessage = _userBLL.ErrorMessage;
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
