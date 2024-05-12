using SuperMarket.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModels
{
    public class LoginViewModel : BasePropertyChanged
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Username
        {
            get => _username;
            set {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                NotifyPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommnad { get; }

        public LoginViewModel()
        {
            LoginCommnad = new RelayCommand(ExecuteLoginCommnad, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validDate;
            if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validDate = false;
            }
            else
            {
                validDate = true;
            }
            return validDate;
        }

        private void ExecuteLoginCommnad(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
