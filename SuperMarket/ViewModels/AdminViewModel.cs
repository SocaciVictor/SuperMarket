using SuperMarket.Helpers;
using SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModels
{
    public class AdminViewModel: BasePropertyChanged
    {
        //asta este comanda pt toate menuItem-urile
        public RelayCommand OpenWindowCommand => new RelayCommand(OpenWindow);

        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    ProductView prod = new ProductView();
                    prod.ShowDialog();
                    break;
                //case "2":
                //    PhoneView phone = new PhoneView();
                //    phone.ShowDialog();
                //    break;
                //case "3":
                //    PersonsWOPhonesView persWoPhone = new PersonsWOPhonesView();
                //    persWoPhone.ShowDialog();
                //    break;
                //case "4":
                //    //AnotherPersonView anotherPers = new AnotherPersonView();
                //    //anotherPers.ShowDialog();
                //    break;
            }
        }
    }
}
