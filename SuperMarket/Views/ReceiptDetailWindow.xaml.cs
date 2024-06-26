﻿using SuperMarket.Models;
using SuperMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperMarket.Views
{
    /// <summary>
    /// Interaction logic for ReceiptDetailWindow.xaml
    /// </summary>
    public partial class ReceiptDetailWindow : Window
    {
        public ReceiptDetailWindow(object param)
        {
            ReceiptDetailViewModel dataContext = new ReceiptDetailViewModel(param);
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
