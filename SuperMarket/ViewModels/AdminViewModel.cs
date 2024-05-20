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
                case "2":
                    UserView user = new UserView();
                    user.ShowDialog();
                    break;
                case "3":
                    CategoryView category = new CategoryView();
                    category.ShowDialog();
                    break;
                case "4":
                    ProducerView producer = new ProducerView();
                    producer.ShowDialog();
                    break;
            }
        }
    }
}
