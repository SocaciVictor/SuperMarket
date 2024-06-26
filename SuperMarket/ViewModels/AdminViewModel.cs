﻿using SuperMarket.Helpers;
using SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                case "5":
                    StockView stock = new StockView();
                    stock.ShowDialog();
                    break;
                case "6":
                    ReceiptView receipt = new ReceiptView();
                    receipt.ShowDialog();
                    break;
            }
        }

        private ICommand _backToLoginCommand;
        public ICommand BackToLoginCommand
        {
            get
            {
                if (_backToLoginCommand == null)
                    _backToLoginCommand = new RelayCommand(BackToLogin);
                return _backToLoginCommand;
            }
        }

        private void BackToLogin(object obj)
        {

            LoginView loginView = new LoginView();
            loginView.Show();


            if (obj is Window currentView)
            {
                currentView.Close();
            }
        }
    }
}
