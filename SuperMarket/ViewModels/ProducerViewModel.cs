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
    public class ProducerViewModel : BasePropertyChanged
    {
        private ProducerBLL _producerBLL;
        public ProducerViewModel()
        {
            _producerBLL = new ProducerBLL();
            ProducerList = _producerBLL.GetAllProducers();
        }

        #region Data Members

        public ObservableCollection<Producer> ProducerList 
        {
            get => _producerBLL.ProducersList;
            set => _producerBLL.ProducersList = value;
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
            _producerBLL.AddMethod(obj);
            ErrorMessage = _producerBLL.ErrorMessage;
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
            _producerBLL.UpdateMethod(obj);
            ErrorMessage = _producerBLL.ErrorMessage;
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
            _producerBLL.DeleteMethod(obj);
            ErrorMessage = _producerBLL.ErrorMessage;
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
